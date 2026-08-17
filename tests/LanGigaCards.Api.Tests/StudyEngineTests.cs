using LanGigaCards.Api.Entities;
using LanGigaCards.Api.Services;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// The scheduler decides when every card comes back. It touches no database,
/// so it is worth pinning down exactly.
/// </summary>
public sealed class StudyEngineTests
{
    private static readonly DateTime ReviewedAt = new(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Again_resets_the_interval_and_returns_the_card_within_the_session()
    {
        var schedule = StudyEngine.CalculateReviewSchedule(10, 2.5, "Again", ReviewedAt);

        Assert.Equal(0, schedule.IntervalDays);
        Assert.Equal(ReviewedAt.AddMinutes(10), schedule.NextReviewDate);
        Assert.Equal(-1, schedule.MasteryDelta);
        Assert.Equal(2.3, schedule.EaseFactor, 3);
    }

    [Fact]
    public void A_first_review_starts_at_one_day_for_medium_and_four_for_easy()
    {
        Assert.Equal(1, StudyEngine.CalculateReviewSchedule(0, 2.5, "Medium", ReviewedAt).IntervalDays);
        Assert.Equal(4, StudyEngine.CalculateReviewSchedule(0, 2.5, "Easy", ReviewedAt).IntervalDays);
    }

    [Fact]
    public void Medium_multiplies_the_interval_by_the_ease_factor()
    {
        var schedule = StudyEngine.CalculateReviewSchedule(4, 2.5, "Medium", ReviewedAt);

        Assert.Equal(10, schedule.IntervalDays);
        Assert.Equal(ReviewedAt.AddDays(10), schedule.NextReviewDate);
        Assert.Equal(2.5, schedule.EaseFactor, 3);
    }

    [Theory]
    [InlineData("Again", 1.3)]
    [InlineData("Hard", 1.3)]
    public void The_ease_factor_never_falls_below_the_floor(string rating, double expected)
    {
        var schedule = StudyEngine.CalculateReviewSchedule(5, 1.3, rating, ReviewedAt);

        Assert.Equal(expected, schedule.EaseFactor, 3);
    }

    [Fact]
    public void The_ease_factor_never_rises_above_the_ceiling()
    {
        var schedule = StudyEngine.CalculateReviewSchedule(5, 3.0, "Easy", ReviewedAt);

        Assert.Equal(3.0, schedule.EaseFactor, 3);
    }

    [Fact]
    public void An_unknown_rating_is_a_programming_error_not_a_default()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => StudyEngine.CalculateReviewSchedule(1, 2.5, "Perfect", ReviewedAt));
    }

    [Fact]
    public void Xp_drives_the_level_and_neither_can_go_negative()
    {
        var user = new User { TotalXp = 40, Level = 1 };

        StudyEngine.ApplyXp(user, 260);
        Assert.Equal(300, user.TotalXp);
        Assert.Equal(4, user.Level);

        StudyEngine.ApplyXp(user, -1000);
        Assert.Equal(0, user.TotalXp);
        Assert.Equal(1, user.Level);
    }

    [Fact]
    public void Yesterday_still_counts_towards_the_current_streak_but_a_gap_does_not()
    {
        var today = new DateTime(2026, 8, 17, 0, 0, 0, DateTimeKind.Utc);
        var unbroken = new[] { today.AddDays(-2), today.AddDays(-1) };
        var broken = new[] { today.AddDays(-4), today.AddDays(-3) };

        // Studying yesterday but not yet today must not zero the streak — the
        // day is not over.
        Assert.Equal(2, StudyEngine.CalculateCurrentStreak(unbroken, today));
        Assert.Equal(0, StudyEngine.CalculateCurrentStreak(broken, today));
    }

    [Fact]
    public void The_longest_streak_is_the_longest_run_of_consecutive_days()
    {
        var start = new DateTime(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc);
        var dates = new[]
        {
            start, start.AddDays(1), start.AddDays(2),      // run of 3
            start.AddDays(5),                               // gap
            start.AddDays(7), start.AddDays(8)              // run of 2
        };

        Assert.Equal(3, StudyEngine.CalculateLongestStreak(dates));
        Assert.Equal(0, StudyEngine.CalculateLongestStreak(Array.Empty<DateTime>()));
    }
}
