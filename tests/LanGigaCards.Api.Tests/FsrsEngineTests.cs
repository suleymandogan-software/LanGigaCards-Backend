using LanGigaCards.Api.Services;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Zamanlayıcı her kartın ne zaman geri geleceğine karar veriyor ve
/// veritabanına hiç dokunmuyor, bu yüzden tam olarak sabitlemeye değer.
/// </summary>
public sealed class FsrsEngineTests
{
    private static readonly DateTime ReviewedAt = new(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void A_first_review_leaves_the_card_with_real_memory_state()
    {
        var review = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt);

        // Stability sıfırdan büyük olmalı: FsrsEngine sıfırı "hiç tekrar
        // edilmemiş" diye okuyor, yani sıfır kalsaydı kart bir sonraki
        // tekrarında yine ilk tekrar yolundan geçerdi.
        Assert.True(review.Stability > 0);
        Assert.InRange(review.Difficulty, 1, 10);
        Assert.True(review.NextReviewDate > ReviewedAt);
    }

    [Fact]
    public void Again_brings_the_card_back_within_the_session()
    {
        var review = FsrsEngine.ReviewCard(12, 5, ReviewedAt.AddDays(-10), "Again", ReviewedAt);

        // Uzun vadeli aralıktan bağımsız, kısa bir yeniden öğrenme adımı.
        Assert.Equal(ReviewedAt.AddMinutes(10), review.NextReviewDate);
    }

    [Fact]
    public void An_easier_rating_pushes_the_card_further_out()
    {
        var hard = FsrsEngine.ReviewCard(0, 0, null, "Hard", ReviewedAt);
        var medium = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt);
        var easy = FsrsEngine.ReviewCard(0, 0, null, "Easy", ReviewedAt);

        Assert.True(hard.NextReviewDate < medium.NextReviewDate);
        Assert.True(medium.NextReviewDate < easy.NextReviewDate);
    }

    [Fact]
    public void Repeated_success_keeps_stretching_the_interval()
    {
        var stability = 0.0;
        var difficulty = 0.0;
        DateTime? last = null;
        var at = ReviewedAt;
        var intervals = new List<double>();

        for (var i = 0; i < 4; i++)
        {
            var review = FsrsEngine.ReviewCard(stability, difficulty, last, "Medium", at);
            intervals.Add((review.NextReviewDate - at).TotalDays);

            stability = review.Stability;
            difficulty = review.Difficulty;
            last = at;
            at = review.NextReviewDate;
        }

        // Her seferinde tam zamanında tekrar eden biri için aralık büyümeli.
        Assert.True(
            intervals.Zip(intervals.Skip(1), (a, b) => b > a).All(grew => grew),
            $"aralik buyumeliydi: {string.Join(", ", intervals)}");
    }

    [Fact]
    public void A_backfilled_row_is_not_treated_as_a_brand_new_card()
    {
        // Migration eski SM-2 satırlarını Stability > 0 ile dolduruyor. Bu
        // satırın bir sonraki tekrarı, kartın geçmişini yok sayan ilk tekrar
        // yolundan geçmemeli.
        var fresh = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt);
        var backfilled = FsrsEngine.ReviewCard(30, 5, ReviewedAt.AddDays(-30), "Medium", ReviewedAt);

        Assert.True(backfilled.NextReviewDate > fresh.NextReviewDate);
        Assert.True(backfilled.Stability > fresh.Stability);
    }

    [Fact]
    public void The_default_cefr_level_changes_nothing()
    {
        var withoutLevel = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt);
        var atB1 = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt, cefrLevel: "B1");

        // B1 alanın kendi varsayılanı: bu ayara hiç dokunmamış bir hesabın
        // davranışı değişmemeli.
        Assert.Equal(0, FsrsEngine.ProficiencyDifficultyOffsetFor("B1"));
        Assert.Equal(withoutLevel.Difficulty, atB1.Difficulty, 6);
        Assert.Equal(withoutLevel.NextReviewDate, atB1.NextReviewDate);
    }

    [Fact]
    public void A_beginner_starts_a_new_word_harder_than_a_near_fluent_learner()
    {
        var beginner = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt, cefrLevel: "A1");
        var advanced = FsrsEngine.ReviewCard(0, 0, null, "Medium", ReviewedAt, cefrLevel: "C2");

        Assert.True(beginner.Difficulty > advanced.Difficulty);
    }

    [Fact]
    public void An_unrecognised_cefr_level_applies_no_nudge()
    {
        // Alan doğrulanmıyor: istemci eski "Adaptive" değerini gönderirse
        // davranış değişmemeli.
        Assert.Equal(0, FsrsEngine.ProficiencyDifficultyOffsetFor("Adaptive"));
        Assert.Equal(0, FsrsEngine.ProficiencyDifficultyOffsetFor(null));
    }

    [Fact]
    public void An_unknown_rating_is_a_programming_error_not_a_default()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => FsrsEngine.ReviewCard(1, 5, null, "Perfect", ReviewedAt));
    }

    [Fact]
    public void Recall_probability_decays_with_time_and_is_zero_before_the_first_review()
    {
        Assert.Equal(0, FsrsEngine.Retrievability(0, 5));

        var sameDay = FsrsEngine.Retrievability(10, 0);
        var atStability = FsrsEngine.Retrievability(10, 10);
        var muchLater = FsrsEngine.Retrievability(10, 100);

        Assert.True(sameDay > atStability);
        Assert.True(atStability > muchLater);

        // Kararlılık tanımı gereği: stability kadar gün sonra hatırlama
        // olasılığı yaklaşık yüzde 90.
        Assert.Equal(0.9, atStability, 2);
    }

    [Fact]
    public void A_longer_lasting_memory_reports_a_higher_mastery_level()
    {
        var early = FsrsEngine.ReviewCard(0, 0, null, "Hard", ReviewedAt);
        var seasoned = FsrsEngine.ReviewCard(120, 4, ReviewedAt.AddDays(-100), "Easy", ReviewedAt);

        Assert.InRange(early.MasteryLevel, 0, 5);
        Assert.InRange(seasoned.MasteryLevel, 0, 5);
        Assert.True(seasoned.MasteryLevel > early.MasteryLevel);
    }
}
