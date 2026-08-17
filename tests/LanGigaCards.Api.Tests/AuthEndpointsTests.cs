using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

public sealed class AuthEndpointsTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public AuthEndpointsTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task Register_then_login_then_refresh_issues_a_working_session()
    {
        var client = _factory.CreateClient();
        var registered = await client.RegisterAsync("flow@example.com");

        Assert.False(string.IsNullOrWhiteSpace(registered.Token));
        Assert.False(string.IsNullOrWhiteSpace(registered.RefreshToken));

        var login = await client.PostAsJsonAsync("/api/Auth/login", new
        {
            Email = "flow@example.com",
            Password = "Str0ngPassw0rd!"
        });
        Assert.Equal(HttpStatusCode.OK, login.StatusCode);

        var session = await ApiClientExtensions.ReadSessionAsync(login, "flow@example.com");
        Assert.Equal(registered.UserId, session.UserId);

        var refresh = await client.PostAsJsonAsync("/api/Auth/refresh", new
        {
            RefreshToken = session.RefreshToken
        });
        Assert.Equal(HttpStatusCode.OK, refresh.StatusCode);
    }

    [Fact]
    public async Task A_refresh_token_cannot_be_redeemed_twice()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("rotation@example.com");

        var first = await client.PostAsJsonAsync("/api/Auth/refresh", new { session.RefreshToken });
        Assert.Equal(HttpStatusCode.OK, first.StatusCode);

        // Rotation is the whole point of storing the token: replaying a spent
        // one is the signal that it was stolen, and it must not work.
        var replay = await client.PostAsJsonAsync("/api/Auth/refresh", new { session.RefreshToken });
        Assert.Equal(HttpStatusCode.Unauthorized, replay.StatusCode);
    }

    [Fact]
    public async Task Login_with_the_wrong_password_is_rejected()
    {
        var client = _factory.CreateClient();
        await client.RegisterAsync("wrongpass@example.com");

        var response = await client.PostAsJsonAsync("/api/Auth/login", new
        {
            Email = "wrongpass@example.com",
            Password = "not-the-password"
        });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Registering_the_same_email_twice_is_rejected()
    {
        var client = _factory.CreateClient();
        await client.RegisterAsync("duplicate@example.com");

        var second = await client.PostAsJsonAsync("/api/Auth/register", new
        {
            FirstName = "Test",
            LastName = "User",
            Email = "duplicate@example.com",
            Password = "Str0ngPassw0rd!",
            ConfirmPassword = "Str0ngPassw0rd!"
        });

        Assert.Equal(HttpStatusCode.BadRequest, second.StatusCode);
    }

    [Fact]
    public async Task Forgot_password_answers_identically_for_known_and_unknown_addresses()
    {
        var client = _factory.CreateClient();
        await client.RegisterAsync("known@example.com");

        var known = await client.PostAsJsonAsync("/api/Auth/forgot-password", new { Email = "known@example.com" });
        var unknown = await client.PostAsJsonAsync("/api/Auth/forgot-password", new { Email = "nobody@example.com" });

        Assert.Equal(HttpStatusCode.OK, known.StatusCode);
        Assert.Equal(HttpStatusCode.OK, unknown.StatusCode);

        // Anti-enumeration: any difference here tells an attacker which
        // addresses have accounts.
        Assert.Equal(await ReadMessageAsync(known), await ReadMessageAsync(unknown));
    }

    private static async Task<string> ReadMessageAsync(HttpResponseMessage response)
    {
        using var document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        return document.RootElement.GetProperty("message").GetString()!;
    }
}
