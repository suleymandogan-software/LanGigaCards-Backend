using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Kart quizi: sorular istemcide öğrenenin kendi kartlarından üretiliyor,
/// sunucu sonucu kaydediyor. Doğruluk o quizin başarısı, tamamlama ise
/// gösterilen ayrı kelime sayısı.
/// </summary>
public sealed class CardQuizTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public CardQuizTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Accuracy_ignores_skipped_questions_and_completion_counts_words_seen()
    {
        var (client, deckId, wordIds) = await DeckWithCardsAsync("card-quiz@example.com", 4);

        var response = await client.PostAsJsonAsync("/api/Quiz/card-sessions", new
        {
            DeckId = deckId,
            Answers = new object[]
            {
                new { WordId = wordIds[0], IsCorrect = true, Skipped = false, TimeSpentSeconds = 5 },
                new { WordId = wordIds[1], IsCorrect = false, Skipped = false, TimeSpentSeconds = 5 },
                new { WordId = wordIds[2], IsCorrect = false, Skipped = true, TimeSpentSeconds = 20 }
            }
        });
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal(3, body.GetProperty("totalQuestions").GetInt32());
        Assert.Equal(1, body.GetProperty("correctCount").GetInt32());
        Assert.Equal(1, body.GetProperty("wrongCount").GetInt32());
        Assert.Equal(1, body.GetProperty("skippedCount").GetInt32());

        // Atlanan soru paydaya girmiyor: 1 doğru / 2 cevaplanmış.
        Assert.Equal(50.0, body.GetProperty("accuracyPercent").GetDouble());

        // Tamamlama doğruluğa bakmaz: üç kelime de gösterildi, dördüncüsü değil.
        Assert.Equal(3, body.GetProperty("wordsSeen").GetInt32());
        Assert.Equal(4, body.GetProperty("wordsInScope").GetInt32());
        Assert.Equal(75.0, body.GetProperty("completionPercent").GetDouble());
    }

    [Fact]
    public async Task Seeing_the_same_word_again_does_not_move_completion()
    {
        var (client, deckId, wordIds) = await DeckWithCardsAsync("repeat-word@example.com", 2);

        object Submit(int wordId) => new
        {
            DeckId = deckId,
            Answers = new object[] { new { WordId = wordId, IsCorrect = true, Skipped = false, TimeSpentSeconds = 3 } }
        };

        (await client.PostAsJsonAsync("/api/Quiz/card-sessions", Submit(wordIds[0]))).EnsureSuccessStatusCode();
        var second = await client.PostAsJsonAsync("/api/Quiz/card-sessions", Submit(wordIds[0]));
        second.EnsureSuccessStatusCode();

        var body = await second.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal(1, body.GetProperty("wordsSeen").GetInt32());
        Assert.Equal(50.0, body.GetProperty("completionPercent").GetDouble());
    }

    [Fact]
    public async Task Completion_can_be_read_without_taking_a_quiz()
    {
        var (client, deckId, _) = await DeckWithCardsAsync("completion-only@example.com", 2);

        var body = await client.GetFromJsonAsync<JsonElement>($"/api/Quiz/card-completion?deckId={deckId}");

        Assert.Equal(0, body.GetProperty("wordsSeen").GetInt32());
        Assert.Equal(2, body.GetProperty("wordsInScope").GetInt32());
        Assert.Equal(0.0, body.GetProperty("completionPercent").GetDouble());
    }

    [Fact]
    public async Task Someone_elses_card_cannot_be_pushed_into_the_statistics()
    {
        var (_, _, otherWordIds) = await DeckWithCardsAsync("victim@example.com", 1);
        var (client, deckId, _) = await DeckWithCardsAsync("intruder@example.com", 1);

        var response = await client.PostAsJsonAsync("/api/Quiz/card-sessions", new
        {
            DeckId = deckId,
            Answers = new object[]
            {
                new { WordId = otherWordIds[0], IsCorrect = true, Skipped = false, TimeSpentSeconds = 5 }
            }
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task A_perfect_submission_unlocks_the_Perfect_Score_achievement_in_the_same_request()
    {
        // Regression: the achievement check used to run before the quiz
        // session it depends on was saved, so a query for "do I have a
        // completed, perfect QuizSession" could never see the one that just
        // finished -- Perfect Score could never unlock on the submission
        // that actually earned it.
        var (client, deckId, wordIds) = await DeckWithCardsAsync("perfect-score@example.com", 2);

        var response = await client.PostAsJsonAsync("/api/Quiz/card-sessions", new
        {
            DeckId = deckId,
            Answers = new object[]
            {
                new { WordId = wordIds[0], IsCorrect = true, Skipped = false, TimeSpentSeconds = 5 },
                new { WordId = wordIds[1], IsCorrect = true, Skipped = false, TimeSpentSeconds = 5 }
            }
        });
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal(100.0, body.GetProperty("accuracyPercent").GetDouble());

        var unlocked = body.GetProperty("newlyUnlockedAchievements").EnumerateArray()
            .Select(badge => badge.GetProperty("name").GetString())
            .ToList();
        Assert.Contains("Perfect Score", unlocked);
    }

    [Fact]
    public async Task An_empty_submission_is_rejected()
    {
        var (client, deckId, _) = await DeckWithCardsAsync("empty-quiz@example.com", 1);

        var response = await client.PostAsJsonAsync("/api/Quiz/card-sessions", new
        {
            DeckId = deckId,
            Answers = Array.Empty<object>()
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task<(HttpClient Client, int DeckId, List<int> WordIds)> DeckWithCardsAsync(string email, int cardCount)
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

        var created = await client.PostAsJsonAsync("/api/Deck", new { Title = "Quiz destesi", Description = string.Empty });
        created.EnsureSuccessStatusCode();
        var deckId = (await created.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt32();

        var wordIds = new List<int>();
        for (var i = 0; i < cardCount; i++)
        {
            var card = await client.PostAsJsonAsync("/api/Flashcard", new
            {
                DeckId = deckId,
                Term = $"Wort{i}",
                Translation = $"Kelime{i}"
            });
            card.EnsureSuccessStatusCode();
            wordIds.Add((await card.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("wordId").GetInt32());
        }

        return (client, deckId, wordIds);
    }
}
