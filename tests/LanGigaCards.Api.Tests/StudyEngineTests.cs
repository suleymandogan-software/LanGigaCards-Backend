using LanGigaCards.Api.Entities;
using LanGigaCards.Api.Services;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// XP, seviye ve çalışma serisi. Veritabanına hiç dokunmuyorlar, bu yüzden tam
/// olarak sabitlemeye değer. Tekrar zamanlaması artık burada değil, bkz.
/// <see cref="FsrsEngineTests"/>.
/// </summary>
public sealed class StudyEngineTests
{
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
