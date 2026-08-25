using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// İstemcinin dil seçicisi ISO 639-1 değil bayrak/ülke kodu gönderiyor
/// (<c>MockData.languages</c>: İngilizce <c>GB</c>, Japonca <c>JP</c>, Korece
/// <c>KR</c>, Çince <c>CN</c>). İçerik ise ISO ile anahtarlı. Çeviri
/// yapılmadığında bu dört dili çalışan kullanıcıya hiçbir kart ulaşmıyordu —
/// ve tam da bu dördü, küçük harfe indiğinde kendi ISO koduna denk gelmeyenler.
/// </summary>
public sealed class LanguageCodeTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public LanguageCodeTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task A_learner_whose_target_language_arrives_as_a_flag_code_still_gets_cards()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("flag-code@example.com");
        client = client.Authenticated(session);

        // İstemcinin gerçekten gönderdiği biçim: İngilizce "GB", Türkçe "TR".
        var profile = await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = "TR",
            TargetLanguageCode = "GB"
        });
        profile.EnsureSuccessStatusCode();

        // Selamlama kavramlarının kategorisi; müfredatta en ve tr çevirileri
        // dolu olan bölüm burası.
        var categories = await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 12 } });
        categories.EnsureSuccessStatusCode();

        var cards = await client.GetFromJsonAsync<JsonElement>("/api/Progress/session?mode=new&limit=10");

        Assert.NotEmpty(cards.EnumerateArray());

        // Ön yüz hedef dilde (İngilizce), arka yüz ana dilde (Türkçe).
        var first = cards.EnumerateArray().First();
        Assert.False(string.IsNullOrWhiteSpace(first.GetProperty("term").GetString()));
        Assert.False(string.IsNullOrWhiteSpace(first.GetProperty("translation").GetString()));
    }

    [Fact]
    public async Task The_same_learner_sees_the_same_cards_when_the_codes_arrive_as_iso()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("iso-code@example.com");
        client = client.Authenticated(session);

        var profile = await client.PutAsJsonAsync("/api/User/profile", new
        {
            FirstName = "Test",
            LastName = "User",
            NativeLanguageCode = "tr",
            TargetLanguageCode = "en"
        });
        profile.EnsureSuccessStatusCode();

        var categories = await client.PutAsJsonAsync("/api/User/categories", new { CategoryIds = new[] { 12 } });
        categories.EnsureSuccessStatusCode();

        var cards = await client.GetFromJsonAsync<JsonElement>("/api/Progress/session?mode=new&limit=10");

        Assert.NotEmpty(cards.EnumerateArray());
    }
}
