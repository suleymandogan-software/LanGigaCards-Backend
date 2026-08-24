using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace LanGigaCards.Api.Tests;

public sealed class SupportEndpointsTests : IClassFixture<LanGigaCardsApiFactory>
{
    private readonly LanGigaCardsApiFactory _factory;

    public SupportEndpointsTests(LanGigaCardsApiFactory factory) => _factory = factory;

    [Fact]
    public async Task A_problem_report_is_accepted_from_a_signed_in_user()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("reporter@example.com");

        var response = await client.Authenticated(session)
            .PostAsJsonAsync("/api/Support/report", new { Message = "Kartlar yüklenmiyor." });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task An_empty_report_is_rejected()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("empty-report@example.com");

        var response = await client.Authenticated(session)
            .PostAsJsonAsync("/api/Support/report", new { Message = string.Empty });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task A_report_longer_than_the_column_is_rejected_before_the_database()
    {
        var client = _factory.CreateClient();
        var session = await client.RegisterAsync("long-report@example.com");

        var response = await client.Authenticated(session)
            .PostAsJsonAsync("/api/Support/report", new { Message = new string('a', 4001) });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Reporting_requires_authentication()
    {
        var response = await _factory.CreateClient()
            .PostAsJsonAsync("/api/Support/report", new { Message = "anonim" });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
