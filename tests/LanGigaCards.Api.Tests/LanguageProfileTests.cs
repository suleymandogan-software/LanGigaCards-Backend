using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Her hedef dilin kendi durumu var: seviye, konu seçimi, seri ve XP. İkinci
/// bir dile geçmek profili değiştirmez, yeni bir öğrenme başlatır.
/// </summary>
public sealed class LanguageProfileTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public LanguageProfileTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Switching_to_a_new_language_opens_an_unfinished_profile()
    {
        var client = await LearnerAsync("switch-new@example.com");

        var response = await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "JP" });
        response.EnsureSuccessStatusCode();

        var profile = await response.Content.ReadFromJsonAsync<JsonElement>();
        // Bayrak kodu ISO olarak saklanıyor, yoksa "gb İngilizcesi" ile
        // "en İngilizcesi" iki ayrı dil sayılırdı.
        Assert.Equal("ja", profile.GetProperty("languageCode").GetString());
        Assert.False(profile.GetProperty("isSetupCompleted").GetBoolean());
        Assert.Empty(profile.GetProperty("categoryIds").EnumerateArray());

        // Kurulum tamamlanmadan kitaplık kurulmaz.
        Assert.Empty((await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray());
    }

    [Fact]
    public async Task The_setup_call_records_the_level_and_builds_the_library_in_one_request()
    {
        var client = await LearnerAsync("setup-builds@example.com");
        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "DE" })).EnsureSuccessStatusCode();

        var response = await client.PutAsJsonAsync("/api/User/languages/de/setup", new
        {
            ProficiencyLevel = "Intermediate",
            CategoryIds = new[] { 4, 7 }
        });
        response.EnsureSuccessStatusCode();

        var profile = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.True(profile.GetProperty("isSetupCompleted").GetBoolean());
        Assert.Equal("Intermediate", profile.GetProperty("proficiencyLevel").GetString());
        // Seviye verilmediğinde tavan yeterlilikten türetilir.
        Assert.Equal("B2", profile.GetProperty("difficultyMode").GetString());

        var decks = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().ToList();
        Assert.Equal(2, decks.Count);
    }

    [Fact]
    public async Task Each_language_keeps_its_own_level_and_topics()
    {
        var client = await LearnerAsync("two-languages@example.com");

        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "DE" })).EnsureSuccessStatusCode();
        (await client.PutAsJsonAsync("/api/User/languages/de/setup", new
        {
            ProficiencyLevel = "Advanced",
            CategoryIds = new[] { 4 }
        })).EnsureSuccessStatusCode();

        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "JP" })).EnsureSuccessStatusCode();
        (await client.PutAsJsonAsync("/api/User/languages/ja/setup", new
        {
            ProficiencyLevel = "Just Starting",
            CategoryIds = new[] { 7 }
        })).EnsureSuccessStatusCode();

        var german = await client.GetFromJsonAsync<JsonElement>("/api/User/languages/de");
        var japanese = await client.GetFromJsonAsync<JsonElement>("/api/User/languages/ja");

        Assert.Equal("Advanced", german.GetProperty("proficiencyLevel").GetString());
        Assert.Equal("Just Starting", japanese.GetProperty("proficiencyLevel").GetString());
        Assert.Equal(new[] { 4 }, german.GetProperty("categoryIds").EnumerateArray().Select(x => x.GetInt32()));
        Assert.Equal(new[] { 7 }, japanese.GetProperty("categoryIds").EnumerateArray().Select(x => x.GetInt32()));

        // Japonca yeni başlayan biri için deste dar, Almanca ileri seviye için
        // geniş: tavan dile göre uygulanıyor.
        var japaneseDeck = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Single();
        Assert.Equal(10, japaneseDeck.GetProperty("cardCount").GetInt32());

        var languages = (await client.GetFromJsonAsync<JsonElement>("/api/User/languages")).EnumerateArray().ToList();
        Assert.Equal(2, languages.Count);
    }

    [Fact]
    public async Task Coming_back_to_a_language_finds_it_where_it_was_left()
    {
        var client = await LearnerAsync("round-trip@example.com");
        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "DE" })).EnsureSuccessStatusCode();
        (await client.PutAsJsonAsync("/api/User/languages/de/setup", new
        {
            ProficiencyLevel = "Beginner",
            CategoryIds = new[] { 4 }
        })).EnsureSuccessStatusCode();
        var germanDecks = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Count();

        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "ES" })).EnsureSuccessStatusCode();

        var back = await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "DE" });
        back.EnsureSuccessStatusCode();

        // Var olan satır sıfırlanmıyor; kurulum bir kez yapıldı.
        var profile = await back.Content.ReadFromJsonAsync<JsonElement>();
        Assert.True(profile.GetProperty("isSetupCompleted").GetBoolean());
        Assert.Equal(germanDecks, (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Count());
    }

    [Fact]
    public async Task A_language_the_learner_never_picked_is_not_found()
    {
        var client = await LearnerAsync("never-picked@example.com");

        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync("/api/User/languages/ko")).StatusCode);
    }

    [Fact]
    public async Task Switching_to_a_language_matching_the_app_language_succeeds()
    {
        // NativeLanguageCode is just the account's App Language (interface
        // locale) now, not a paired "native" half of a native/target
        // couple -- it no longer restricts which languages can be learned.
        // A learner whose App Language happens to be Turkish must still be
        // able to pick Turkish as a target.
        var client = await LearnerAsync("app-language-match@example.com");

        var response = await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "TR" });

        response.EnsureSuccessStatusCode();
        var profile = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("tr", profile.GetProperty("languageCode").GetString());
    }

    private async Task<HttpClient> LearnerAsync(string email)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        client = client.Authenticated(session);

        (await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = "TR",
            TargetLanguageCode = "TR"
        })).EnsureSuccessStatusCode();
        return client;
    }
}
