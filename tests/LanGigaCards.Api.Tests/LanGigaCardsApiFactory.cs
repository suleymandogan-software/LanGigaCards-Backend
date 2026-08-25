using LanGigaCards.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace LanGigaCards.Api.Tests;

/// <summary>
/// Boots the real API — the same routing, authentication, rate limiting and
/// controller pipeline Program.cs builds — against a throwaway SQLite database.
/// </summary>
public sealed class LanGigaCardsApiFactory : WebApplicationFactory<Program>
{
    public const string Issuer = "LanGigaCardsApiTests";
    public const string Audience = "LanGigaCardsApiTests";

    // The connection is held open for the lifetime of the factory: an
    // in-memory SQLite database exists only as long as a connection to it does,
    // so closing it between requests would drop every table.
    private readonly SqliteConnection _connection = new("DataSource=:memory:");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Not "Development": that branch runs Database.Migrate(), and the
        // migrations are SQL Server scripts. The schema here comes from
        // EnsureCreated against the same EF model instead.
        builder.UseEnvironment("Testing");

        // Program.cs refuses to start without a signing key, on purpose.
        builder.UseSetting("Jwt:Key", "test-signing-key-that-is-long-enough-for-hmac-sha256");
        builder.UseSetting("Jwt:Issuer", Issuer);
        builder.UseSetting("Jwt:Audience", Audience);

        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<AppDbContext>>();
            services.RemoveAll<DbContextOptions>();
            services.RemoveAll<AppDbContext>();

            OpenConnection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(_connection));
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);

        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();

        return host;
    }

    private void OpenConnection()
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            return;
        }

        _connection.Open();

        // The Deck and Vocabulary CHECK constraints call LEN(), which is T-SQL.
        // SQLite spells it LENGTH and rejects CREATE TABLE outright when a
        // CHECK names a function it does not know, so the shim has to be in
        // place before EnsureCreated runs.
        _connection.CreateFunction("LEN", (string? value) => value?.Length ?? 0);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
        {
            _connection.Dispose();
        }
    }
}
