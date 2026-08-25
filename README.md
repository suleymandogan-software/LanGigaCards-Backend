# LanGigaCards API

The ASP.NET Core backend for LanGigaCards — a flashcard app for learning languages, with
accounts, spaced repetition, curriculum content and progress statistics. The Flutter
client lives in [LanGigaCards1](https://github.com/suleymandogan-software/LanGigaCards1)
and talks to this API on `http://localhost:5068`.

## Tech stack

* **Framework:** ASP.NET Core Web API, targets .NET 8 and runs on .NET 8 or newer
* **Database:** SQL Server, via Entity Framework Core migrations
* **Authentication:** JWT, plus Google and Apple sign-in
* **Tests:** xUnit against the real pipeline, on a throwaway SQLite database

## Quick start

```bash
git clone https://github.com/suleymandogan-software/LanGigaCards-Backend.git
cd LanGigaCards-Backend

# The API refuses to start without a signing key — this is the one required step.
dotnet user-secrets set "Jwt:Key" "A_LONG_RANDOM_SECRET_AT_LEAST_32_CHARS" --project src/LanGigaCards.Api

dotnet run --project src/LanGigaCards.Api   # Swagger: http://localhost:5068/swagger
dotnet test LanGigaCards.slnx
```

The database creates and seeds itself on first run in Development — no script to execute,
nothing to restore. Full walkthrough, including SQL Server and SMTP options, in
[docs/getting-started.md](docs/getting-started.md).

## Layout

```
LanGigaCards.slnx          Open this, not a project file
src/LanGigaCards.Api/      The API
tests/LanGigaCards.Api.Tests/
docs/                      Setup, configuration, API notes, architecture
```

## Features

* **Accounts** — registration and login issuing JWTs, with rotating refresh tokens
* **Email verification** — 6-digit codes, 15-minute lifetime, 5-attempt budget
* **Password reset** — emailed tokens with anti-enumeration responses
* **Decks and flashcards** — per-user, with spaced-repetition scheduling
* **Curriculum content** — 20 lessons from A1 to B2 and 238 vocabulary entries, seeded
* **Statistics** — daily study rollups, streaks, XP and achievements
* **Data integrity** — every text column is length-bounded and 23 CHECK constraints
  restate the DTO rules at the table level, so invalid data cannot reach the tables by
  any path

## Documentation

| | |
| --- | --- |
| [Getting started](docs/getting-started.md) | Prerequisites, secrets, database, SMTP, troubleshooting |
| [Configuration](docs/configuration.md) | Every setting, where it belongs, and its default |
| [API notes](docs/api.md) | Auth flow, ownership rules, and what clients get wrong |
| [Architecture](docs/architecture.md) | Layout, layering, and how the tests are built |
| [Contributing](CONTRIBUTING.md) | Branches, commits, migrations, definition of done |
