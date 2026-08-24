using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Kategori seçimi kitaplığa deste kuruyor mu. İstemci (EmreKTR/LanGigaCard)
/// Food/Travel/Business/Family destelerini kendi tarafından sildi ve artık
/// sunucudan bekliyor; bu desteler kurulmazsa kullanıcının kitaplığında
/// yalnızca beş genel deste kalır.
/// </summary>
public sealed class CategoryDeckTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public CategoryDeckTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Choosing_a_category_builds_a_deck_for_it()
    {
        var client = await LearnerAsync("category-deck@example.com", native: "TR", target: "DE");

        var categories = await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } });
        categories.EnsureSuccessStatusCode();

        var decks = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().ToList();

        var deck = Assert.Single(decks);
        Assert.Equal("category_technology_de", deck.GetProperty("starterKey").GetString());
        Assert.True(deck.GetProperty("cardCount").GetInt32() > 0);

        // Deste adı öğrenenin ana dilinde: liste bir gezinme yüzeyi.
        Assert.Equal("Teknoloji", deck.GetProperty("title").GetString());
    }

    [Fact]
    public async Task Deck_cards_are_target_language_on_the_front_and_native_on_the_back()
    {
        var client = await LearnerAsync("card-sides@example.com", native: "TR", target: "DE");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        var deckId = (await client.GetFromJsonAsync<JsonElement>("/api/Deck"))
            .EnumerateArray().First().GetProperty("id").GetInt32();
        var cards = (await client.GetFromJsonAsync<JsonElement>($"/api/Flashcard?deckId={deckId}"))
            .EnumerateArray().ToList();

        var terms = cards.Select(c => c.GetProperty("term").GetString()).ToList();
        var translations = cards.Select(c => c.GetProperty("translation").GetString()).ToList();

        Assert.Contains("Bildschirm", terms);
        Assert.Contains("Ekran", translations);
    }

    [Fact]
    public async Task A_flag_code_target_language_still_produces_a_full_deck()
    {
        // GB/JP/KR/CN, ISO karşılığıyla çakışmayan dört bayrak kodu. Çeviri
        // yapılmadığında şablonun hiçbir kelimesi eşleşmiyor ve deste sessizce
        // hiç kurulmuyordu.
        var client = await LearnerAsync("flag-deck@example.com", native: "TR", target: "JP");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        var deck = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Single();

        Assert.Equal("category_technology_ja", deck.GetProperty("starterKey").GetString());
        Assert.True(deck.GetProperty("cardCount").GetInt32() > 0);
    }

    [Fact]
    public async Task Dropping_a_category_removes_its_untouched_deck()
    {
        var client = await LearnerAsync("drop-category@example.com", native: "TR", target: "DE");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4, 7 } })).EnsureSuccessStatusCode();
        Assert.Equal(2, (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Count());

        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        var deck = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Single();
        Assert.Equal("category_technology_de", deck.GetProperty("starterKey").GetString());
    }

    [Fact]
    public async Task Switching_target_language_rebuilds_the_deck_in_the_new_language()
    {
        var client = await LearnerAsync("switch-language@example.com", native: "TR", target: "DE");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        (await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = "TR",
            TargetLanguageCode = "ES"
        })).EnsureSuccessStatusCode();

        var deck = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Single();
        Assert.Equal("category_technology_es", deck.GetProperty("starterKey").GetString());
    }

    [Fact]
    public async Task A_deck_the_learner_has_studied_survives_dropping_the_category()
    {
        var client = await LearnerAsync("studied-deck@example.com", native: "TR", target: "DE");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        var deckId = (await client.GetFromJsonAsync<JsonElement>("/api/Deck"))
            .EnumerateArray().First().GetProperty("id").GetInt32();
        var wordId = (await client.GetFromJsonAsync<JsonElement>($"/api/Flashcard?deckId={deckId}"))
            .EnumerateArray().First().GetProperty("wordId").GetInt32();

        var reviewed = await client.PostAsJsonAsync($"/api/Progress/reviews/{wordId}", new
        {
            Rating = "Medium",
            DurationSeconds = 5
        });
        reviewed.EnsureSuccessStatusCode();

        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = Array.Empty<int>() })).EnsureSuccessStatusCode();

        // Emeğin üzerine yazmaktansa kitaplıkta fazladan bir deste kalsın.
        var decks = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().ToList();
        Assert.Single(decks);
        Assert.Equal(deckId, decks[0].GetProperty("id").GetInt32());
    }

    [Fact]
    public async Task Raising_the_level_tops_the_existing_deck_up()
    {
        var client = await LearnerAsync("level-up@example.com", native: "TR", target: "DE", proficiency: "Just Starting");
        (await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 4 } })).EnsureSuccessStatusCode();

        var before = (await client.GetFromJsonAsync<JsonElement>("/api/Deck"))
            .EnumerateArray().Single().GetProperty("cardCount").GetInt32();

        (await client.PutAsJsonAsync("/api/User/settings", new
        {
            DarkMode = false,
            DailyReminders = true,
            SoundEffects = true,
            ThemeColor = "Purple",
            TextSize = "Medium",
            DifficultyMode = "C2"
        })).EnsureSuccessStatusCode();

        var after = (await client.GetFromJsonAsync<JsonElement>("/api/Deck"))
            .EnumerateArray().Single().GetProperty("cardCount").GetInt32();

        Assert.True(after > before, $"kart sayisi artmaliydi: {before} -> {after}");
    }

    private async Task<HttpClient> LearnerAsync(string email, string native, string target, string? proficiency = null)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        client = client.Authenticated(session);

        var profile = await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = native,
            TargetLanguageCode = target,
            TargetProficiencyLevel = proficiency ?? string.Empty
        });
        profile.EnsureSuccessStatusCode();
        return client;
    }
}
