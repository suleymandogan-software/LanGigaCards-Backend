using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// İlerleme dil başına ayrı tutuluyor: bir dilde çalışmak diğerinin serisini,
/// XP değerini, istatistiğini ya da tekrar kuyruğunu etkilemiyor.
/// </summary>
public sealed class LanguageScopedProgressTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public LanguageScopedProgressTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Studying_feeds_the_profile_of_the_language_it_belongs_to()
    {
        var client = await LearnerAsync("feeds-profile@example.com");
        var (_, wordId) = await DeckWithCardAsync(client, "Haus", "Ev");

        (await client.PostAsJsonAsync($"/api/Progress/reviews/{wordId}", new
        {
            Rating = "Medium",
            DurationSeconds = 30
        })).EnsureSuccessStatusCode();

        var german = await client.GetFromJsonAsync<JsonElement>("/api/User/languages/de");
        Assert.True(german.GetProperty("totalXp").GetInt32() > 0);
        Assert.Equal(1, german.GetProperty("currentStreak").GetInt32());
        Assert.Equal(wordId, german.GetProperty("lastStudiedWordId").GetInt32());
    }

    [Fact]
    public async Task One_language_progress_does_not_leak_into_another()
    {
        var client = await LearnerAsync("no-leak@example.com");
        var (_, germanWordId) = await DeckWithCardAsync(client, "Haus", "Ev");

        (await client.PostAsJsonAsync($"/api/Progress/reviews/{germanWordId}", new
        {
            Rating = "Medium",
            DurationSeconds = 30
        })).EnsureSuccessStatusCode();

        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "ES" })).EnsureSuccessStatusCode();

        var spanish = await client.GetFromJsonAsync<JsonElement>("/api/User/languages/es");
        Assert.Equal(0, spanish.GetProperty("totalXp").GetInt32());
        Assert.Equal(0, spanish.GetProperty("currentStreak").GetInt32());

        // İstatistik de çalışılan dile bağlı: İspanyolcada hiç çalışılmadı.
        var overview = await client.GetFromJsonAsync<JsonElement>("/api/Statistics/overview");
        Assert.Equal(0, overview.GetProperty("totalStudySeconds").GetInt32());

        // Almancaya dönünce sayılar yerinde.
        var germanOverview = await client.GetFromJsonAsync<JsonElement>("/api/Statistics/overview?languageCode=de");
        Assert.Equal(30, germanOverview.GetProperty("totalStudySeconds").GetInt32());
    }

    [Fact]
    public async Task The_mixed_review_queue_only_offers_the_language_being_studied()
    {
        var client = await LearnerAsync("queue-scope@example.com");
        await DeckWithCardAsync(client, "Haus", "Ev");

        var germanQueue = await client.GetFromJsonAsync<JsonElement>("/api/Progress/reviews/due");
        Assert.NotEmpty(germanQueue.EnumerateArray());

        (await client.PutAsJsonAsync("/api/User/languages/switch", new { LanguageCode = "ES" })).EnsureSuccessStatusCode();

        // Almanca kartlar silinmedi, yalnızca bu dilin kuyruğuna girmiyor.
        var spanishQueue = await client.GetFromJsonAsync<JsonElement>("/api/Progress/reviews/due");
        Assert.Empty(spanishQueue.EnumerateArray());
    }

    private async Task<(int DeckId, int WordId)> DeckWithCardAsync(HttpClient client, string term, string translation)
    {
        var created = await client.PostAsJsonAsync("/api/Deck", new { Title = "Deste", Description = string.Empty });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var card = await client.PostAsJsonAsync("/api/Flashcard", new
        {
            DeckId = deckId,
            Term = term,
            Translation = translation
        });
        card.EnsureSuccessStatusCode();
        var wordId = (await card.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("wordId").GetInt32();
        return (deckId, wordId);
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
            TargetLanguageCode = "DE"
        })).EnsureSuccessStatusCode();
        return client;
    }
}
