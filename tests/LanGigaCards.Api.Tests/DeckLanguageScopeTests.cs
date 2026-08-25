using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Deste listesi öğrenenin o an çalıştığı dille sınırlı. Başka bir dile geçmek
/// eski desteleri silmez; yalnızca görünümden çıkarır, ilerlemeleri yerinde
/// kalır ve o dile dönüldüğünde aynen geri gelirler.
/// </summary>
public sealed class DeckLanguageScopeTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public DeckLanguageScopeTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task A_new_deck_is_stamped_with_the_language_the_learner_is_studying()
    {
        var client = await LearnerAsync("stamp-language@example.com", target: "DE");

        var created = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Kendi destem",
            Description = string.Empty
        });
        created.EnsureSuccessStatusCode();

        var deck = await created.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("de", deck.GetProperty("languageCode").GetString());
    }

    [Fact]
    public async Task A_flag_code_target_language_is_stored_as_its_iso_code()
    {
        var client = await LearnerAsync("stamp-flag@example.com", target: "JP");

        var created = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Japonca deste",
            Description = string.Empty
        });
        created.EnsureSuccessStatusCode();

        var deck = await created.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("ja", deck.GetProperty("languageCode").GetString());
    }

    [Fact]
    public async Task Switching_language_hides_the_deck_and_switching_back_restores_it_with_its_progress()
    {
        var client = await LearnerAsync("scope-roundtrip@example.com", target: "DE");

        var created = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Almanca deste",
            Description = string.Empty
        });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var card = await client.PostAsJsonAsync("/api/Flashcard", new
        {
            DeckId = deckId,
            Term = "Haus",
            Translation = "Ev"
        });
        card.EnsureSuccessStatusCode();
        var wordId = (await card.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("wordId").GetInt32();

        var reviewed = await client.PostAsJsonAsync($"/api/Progress/reviews/{wordId}", new
        {
            Rating = "Medium",
            DurationSeconds = 5
        });
        reviewed.EnsureSuccessStatusCode();

        await SetTargetAsync(client, "ES");
        Assert.Empty((await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray());

        // Silinmedi, yalnızca listeden düştü: doğrudan istenince hâlâ orada.
        var direct = await client.GetFromJsonAsync<JsonElement>($"/api/Deck/{deckId}");
        Assert.Equal(deckId, direct.GetProperty("id").GetInt32());

        await SetTargetAsync(client, "DE");

        var back = (await client.GetFromJsonAsync<JsonElement>("/api/Deck")).EnumerateArray().Single();
        Assert.Equal(deckId, back.GetProperty("id").GetInt32());
        Assert.Equal(1, back.GetProperty("cardCount").GetInt32());
        // Tekrar geçmişi de yerinde durmalı.
        Assert.Equal(1, back.GetProperty("reviewsCount").GetInt32());
    }

    private static async Task SetTargetAsync(HttpClient client, string target)
    {
        var response = await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = "TR",
            TargetLanguageCode = target
        });
        response.EnsureSuccessStatusCode();
    }

    private async Task<HttpClient> LearnerAsync(string email, string target)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        client = client.Authenticated(session);
        await SetTargetAsync(client, target);
        return client;
    }
}
