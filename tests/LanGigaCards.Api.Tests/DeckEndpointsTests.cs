using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

public sealed class DeckEndpointsTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public DeckEndpointsTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Deck_endpoints_reject_an_unauthenticated_caller()
    {
        var response = await _factory.CreateClient().GetAsync("/api/Deck");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task A_created_deck_comes_back_in_the_owner_list()
    {
        var (client, _) = await SignedInClientAsync("owner@example.com");

        var created = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Almanca Temeller",
            Description = "İlk deste"
        });
        Assert.Equal(HttpStatusCode.Created, created.StatusCode);

        var listed = await client.GetFromJsonAsync<JsonElement>("/api/Deck");
        var titles = listed.EnumerateArray().Select(deck => deck.GetProperty("title").GetString()).ToList();

        Assert.Contains("Almanca Temeller", titles);
    }

    [Fact]
    public async Task A_deck_is_invisible_and_untouchable_to_another_account()
    {
        var (ownerClient, _) = await SignedInClientAsync("first@example.com");
        var created = await ownerClient.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Private deck",
            Description = string.Empty
        });
        created.EnsureSuccessStatusCode();

        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var (intruderClient, _) = await SignedInClientAsync("second@example.com");

        // NotFound rather than Forbidden is deliberate in the controller: a 403
        // would confirm the deck exists. The test pins that choice down.
        Assert.Equal(HttpStatusCode.NotFound, (await intruderClient.GetAsync($"/api/Deck/{deckId}")).StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, (await intruderClient.DeleteAsync($"/api/Deck/{deckId}")).StatusCode);

        var intruderDecks = await intruderClient.GetFromJsonAsync<JsonElement>("/api/Deck");
        Assert.Empty(intruderDecks.EnumerateArray());

        // And the owner still has it.
        Assert.Equal(HttpStatusCode.OK, (await ownerClient.GetAsync($"/api/Deck/{deckId}")).StatusCode);
    }

    [Fact]
    public async Task A_blank_title_is_rejected_before_it_reaches_the_database()
    {
        var (client, _) = await SignedInClientAsync("validation@example.com");

        var response = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = string.Empty,
            Description = "no title"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task<(HttpClient Client, TestSession Session)> SignedInClientAsync(string email)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        return (client.Authenticated(session), session);
    }
}
