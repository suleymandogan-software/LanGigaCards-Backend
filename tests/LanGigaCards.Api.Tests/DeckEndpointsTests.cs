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

    [Fact]
    public async Task A_deck_nobody_has_studied_yet_has_nothing_due()
    {
        var (client, _) = await SignedInClientAsync("due-count@example.com");

        var created = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Hiç açılmamış deste",
            Description = string.Empty
        });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        foreach (var (term, translation) in new[] { ("Haus", "Ev"), ("Baum", "Ağaç"), ("Wasser", "Su") })
        {
            var card = await client.PostAsJsonAsync("/api/Flashcard", new
            {
                DeckId = deckId,
                Term = term,
                Translation = translation
            });
            card.EnsureSuccessStatusCode();
        }

        var deck = await client.GetFromJsonAsync<JsonElement>($"/api/Deck/{deckId}");

        // Hiç çalışılmamış kart "tekrar zamanı gelmiş" değildir; ikisi ayrı
        // durumlar. Eskiden ilerleme kaydı olmayan her kart due sayılıyordu, bu
        // yüzden yeni açılmış deste kart sayısının tamamını "tekrar bekliyor"
        // diye gösteriyor, başlanmamış deste ile biriktirmiş deste ekranda
        // birbirinden ayırt edilemiyordu.
        Assert.Equal(3, deck.GetProperty("cardCount").GetInt32());
        Assert.Equal(0, deck.GetProperty("dueCount").GetInt32());
        // studyCount ise dueCount'tan kasıtlı olarak ayrışır: "Study" düğmesine
        // basılırsa gelecek gerçek kart sayısı, GetDueReviews'ın kendi kriteriyle
        // birebir aynı -- hiç çalışılmamış kart da bu sayıma girer.
        Assert.Equal(3, deck.GetProperty("studyCount").GetInt32());
    }

    [Fact]
    public async Task A_partially_studied_deck_still_offers_its_untouched_cards_to_study()
    {
        // Regression: studying 3 of a 10-card deck and leaving used to make
        // the deck claim "all caught up" -- dueCount only counts cards that
        // already have a progress row (see the previous test's own comment),
        // so the 7 cards nobody had touched yet vanished from that count
        // entirely, even though GetDueReviews would still hand them right
        // back on the next session. studyCount is the field meant to answer
        // "how many cards would a session actually contain right now", and
        // must keep counting them.
        var (client, _) = await SignedInClientAsync("partial-study@example.com");

        var created = await client.PostAsJsonAsync("/api/Deck", new { Title = "Kısmi deste", Description = string.Empty });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var wordIds = new List<int>();
        foreach (var (term, translation) in new[]
                 {
                     ("eins", "bir"), ("zwei", "iki"), ("drei", "üç"), ("vier", "dört"), ("fünf", "beş"),
                     ("sechs", "altı"), ("sieben", "yedi"), ("acht", "sekiz"), ("neun", "dokuz"), ("zehn", "on"),
                 })
        {
            var card = await client.PostAsJsonAsync("/api/Flashcard", new { DeckId = deckId, Term = term, Translation = translation });
            card.EnsureSuccessStatusCode();
            wordIds.Add((await card.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("wordId").GetInt32());
        }

        // Rate exactly 3 of the 10, "Medium" -- enough to push their next
        // review into the future, same as a learner glancing at a few cards
        // and leaving mid-deck.
        foreach (var wordId in wordIds.Take(3))
        {
            var reviewed = await client.PostAsJsonAsync($"/api/Progress/reviews/{wordId}", new { Rating = "Medium", DurationSeconds = 5 });
            reviewed.EnsureSuccessStatusCode();
        }

        var deck = await client.GetFromJsonAsync<JsonElement>($"/api/Deck/{deckId}");

        Assert.Equal(10, deck.GetProperty("cardCount").GetInt32());
        Assert.Equal(7, deck.GetProperty("studyCount").GetInt32());
    }

    [Fact]
    public async Task Deleting_the_deck_holding_the_accounts_last_studied_word_still_succeeds()
    {
        // Regression: UserLanguageProfile.LastStudiedDeckId/LastStudiedWordId
        // point at a deck/word with DeleteBehavior.NoAction (see
        // AppDbContext's own comment on that mapping -- deliberate, so a
        // deleted deck doesn't take the language's streak/XP down with it).
        // NoAction means EF won't cascade the delete on its own; the
        // controller has to null those fields out itself. It didn't, so
        // deleting whichever deck happened to hold the account's most
        // recently reviewed word threw a real 500 (FK violation) instead of
        // the deck actually deleting.
        var (client, _) = await SignedInClientAsync("delete-last-studied@example.com");

        var created = await client.PostAsJsonAsync("/api/Deck", new { Title = "Son çalışılan deste", Description = string.Empty });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var card = await client.PostAsJsonAsync("/api/Flashcard", new { DeckId = deckId, Term = "Haus", Translation = "Ev" });
        card.EnsureSuccessStatusCode();
        var wordId = (await card.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("wordId").GetInt32();

        var reviewed = await client.PostAsJsonAsync($"/api/Progress/reviews/{wordId}", new { Rating = "Medium", DurationSeconds = 5 });
        reviewed.EnsureSuccessStatusCode();

        var deleted = await client.DeleteAsync($"/api/Deck/{deckId}");
        Assert.Equal(HttpStatusCode.NoContent, deleted.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync($"/api/Deck/{deckId}")).StatusCode);
    }

    private async Task<(HttpClient Client, TestSession Session)> SignedInClientAsync(string email)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        return (client.Authenticated(session), session);
    }
}
