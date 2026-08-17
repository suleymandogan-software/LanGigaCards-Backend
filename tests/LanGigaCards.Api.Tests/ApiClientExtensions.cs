using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace LanGigaCards.Api.Tests;

/// <summary>The signed-in session a test needs to call protected endpoints.</summary>
public sealed record TestSession(int UserId, string Email, string Token, string RefreshToken);

public static class ApiClientExtensions
{
    /// <summary>
    /// Registers a user through the public endpoint rather than seeding rows
    /// directly, so the tests exercise password hashing and token issuing the
    /// same way the app does.
    /// </summary>
    public static async Task<TestSession> RegisterAsync(
        this HttpClient client,
        string email,
        string password = "Str0ngPassw0rd!")
    {
        var response = await client.PostAsJsonAsync("/api/Auth/register", new
        {
            FirstName = "Test",
            LastName = "User",
            Email = email,
            Password = password,
            ConfirmPassword = password
        });

        response.EnsureSuccessStatusCode();
        return await ReadSessionAsync(response, email);
    }

    public static async Task<TestSession> ReadSessionAsync(HttpResponseMessage response, string email)
    {
        using var document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var root = document.RootElement;

        return new TestSession(
            root.GetProperty("user").GetProperty("id").GetInt32(),
            email,
            root.GetProperty("token").GetString()!,
            root.GetProperty("refreshToken").GetString()!);
    }

    public static HttpClient Authenticated(this HttpClient client, TestSession session)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
        return client;
    }
}
