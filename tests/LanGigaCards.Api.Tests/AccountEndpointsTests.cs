using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Ayarlar ekranının hesap işlemleri: parola değiştirme ve hesap silme.
/// İkisi de istemcinin (EmreKTR/LanGigaCard) çağırdığı ama sunucuda karşılığı
/// olmayan uçlardı.
/// </summary>
public sealed class AccountEndpointsTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public AccountEndpointsTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task A_fresh_account_reports_its_email_as_unverified()
    {
        var (client, _) = await SignedInClientAsync("verify-flag@example.com");

        var profile = await client.GetFromJsonAsync<JsonElement>("/api/User/profile");

        // Alanın *varlığı* asıl mesele: istemci onu okuyor ve yoksa sessizce
        // false'a düşüyordu, yani doğrulanmış hesap bile onaysız görünüyordu.
        Assert.False(profile.GetProperty("isEmailVerified").GetBoolean());
    }

    [Fact]
    public async Task The_current_password_has_to_be_right_to_change_it()
    {
        var (client, _) = await SignedInClientAsync("wrong-current@example.com");

        var response = await client.PutAsJsonAsync("/api/User/password", new
        {
            CurrentPassword = "not-the-password",
            NewPassword = "An0therStr0ng!"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task A_new_password_that_is_too_short_is_rejected()
    {
        var (client, _) = await SignedInClientAsync("short-new@example.com");

        var response = await client.PutAsJsonAsync("/api/User/password", new
        {
            CurrentPassword = "Str0ngPassw0rd!",
            NewPassword = "short"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Changing_the_password_signs_other_devices_out_and_the_new_one_works()
    {
        const string email = "rotate@example.com";
        var (client, session) = await SignedInClientAsync(email);

        var changed = await client.PutAsJsonAsync("/api/User/password", new
        {
            CurrentPassword = "Str0ngPassw0rd!",
            NewPassword = "An0therStr0ng!"
        });
        Assert.Equal(HttpStatusCode.OK, changed.StatusCode);

        // Parola değişimi sıfırlama gibi davranmalı: eldeki refresh token artık
        // yeni erişim token'ı üretemez, yoksa parolayı ele geçirmiş biri
        // kurban parolasını değiştirdikten sonra da oturumda kalırdı.
        var refreshed = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Auth/refresh", new { RefreshToken = session.RefreshToken });
        Assert.Equal(HttpStatusCode.Unauthorized, refreshed.StatusCode);

        var oldPassword = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Auth/login", new { Email = email, Password = "Str0ngPassw0rd!" });
        Assert.Equal(HttpStatusCode.Unauthorized, oldPassword.StatusCode);

        var newPassword = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Auth/login", new { Email = email, Password = "An0therStr0ng!" });
        Assert.Equal(HttpStatusCode.OK, newPassword.StatusCode);
    }

    [Fact]
    public async Task Deleting_an_account_hides_it_everywhere_and_frees_its_email()
    {
        const string email = "delete-me@example.com";
        var (client, session) = await SignedInClientAsync(email);

        var deck = await client.PostAsJsonAsync("/api/Deck", new
        {
            Title = "Gidecek deste",
            Description = string.Empty
        });
        deck.EnsureSuccessStatusCode();

        var deleted = await client.DeleteAsync("/api/User");
        Assert.Equal(HttpStatusCode.NoContent, deleted.StatusCode);

        // Silme işaretlemedir ama işaretli hesap her yerde yok sayılır: elde
        // kalan erişim anahtarı da, yenileme anahtarı da artık işlemez.
        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync("/api/User/profile")).StatusCode);

        var refreshed = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Auth/refresh", new { RefreshToken = session.RefreshToken });
        Assert.Equal(HttpStatusCode.Unauthorized, refreshed.StatusCode);

        var login = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Auth/login", new { Email = email, Password = "Str0ngPassw0rd!" });
        Assert.Equal(HttpStatusCode.Unauthorized, login.StatusCode);

        // Benzersizlik indeksi yalnızca silinmemiş hesapları kapsıyor, yani
        // aynı adres yeniden kullanılabilir.
        var reRegistered = await _factory.CreateClient().PostAsJsonAsync("/api/Auth/register", new
        {
            FirstName = "Test",
            LastName = "User",
            Email = email,
            Password = "Str0ngPassw0rd!",
            ConfirmPassword = "Str0ngPassw0rd!"
        });
        Assert.Equal(HttpStatusCode.OK, reRegistered.StatusCode);

        // Yeni kayıt yeni bir hesap: eskisinin kitaplığını devralmaz.
        var freshSession = await ApiClientExtensions.ReadSessionAsync(reRegistered, email);
        var freshDecks = await _factory.CreateClient().Authenticated(freshSession)
            .GetFromJsonAsync<JsonElement>("/api/Deck");
        Assert.Empty(freshDecks.EnumerateArray());
    }

    [Fact]
    public async Task Account_endpoints_reject_an_unauthenticated_caller()
    {
        var client = _factory.CreateClient();

        Assert.Equal(HttpStatusCode.Unauthorized, (await client.DeleteAsync("/api/User")).StatusCode);
        Assert.Equal(
            HttpStatusCode.Unauthorized,
            (await client.PutAsJsonAsync("/api/User/password", new
            {
                CurrentPassword = "x",
                NewPassword = "An0therStr0ng!"
            })).StatusCode);
    }

    private async Task<(HttpClient Client, TestSession Session)> SignedInClientAsync(string email)
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync(email);
        return (client.Authenticated(session), session);
    }
}
