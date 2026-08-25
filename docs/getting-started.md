# Getting started

Only steps 1–3 need anything from you. Step 4 (the database) happens by itself, and
step 5 (SMTP) is optional — the API runs fine without it.

## Prerequisites

* **.NET SDK 8.0 or newer.** The project targets `net8.0` but sets
  `<RollForward>LatestMajor</RollForward>` in `Directory.Build.props`, so a machine that
  only has the .NET 9 or 10 runtime installed can still run it.
* **SQL Server** — LocalDB (ships with Visual Studio), SQL Server Express, or a full
  instance. You do not need to create a database by hand; the app does that on first run.
* Visual Studio 2022, VS Code, Rider, or Cursor.

The EF Core CLI (`dotnet tool install --global dotnet-ef`) is **optional** — useful for
adding migrations, not needed to run the project.

## 1. Clone and enter the project folder

```bash
git clone https://github.com/suleymandogan-software/LanGigaCards-Backend.git
cd LanGigaCards-Backend
```

Build and test commands run from the repository root, against `LanGigaCards.slnx`.
The `dotnet user-secrets` commands below are the exception: they resolve the secret
store from a project file, so they need `--project src/LanGigaCards.Api` (or a shell
already sitting in that folder).

## 2. Set the JWT signing key (required)

**The API refuses to start without `Jwt:Key`.** This is deliberate: a missing key is a
loud startup failure rather than a silently insecure default.

The project already carries a `UserSecretsId`, so there is no `init` step — just set the
value. Use a long random string, at least 32 characters:

```bash
dotnet user-secrets set "Jwt:Key" "REPLACE_WITH_A_LONG_RANDOM_SECRET_AT_LEAST_32_CHARS" --project src/LanGigaCards.Api
```

Need one generated? On Windows PowerShell:

```powershell
[Convert]::ToBase64String((1..48 | ForEach-Object { Get-Random -Max 256 }))
```

Secrets are stored per-machine, outside the repository, at
`%APPDATA%\Microsoft\UserSecrets\f07a094b-d00a-4a4b-a2bf-526e44ee23a7\secrets.json`
(Windows) or `~/.microsoft/usersecrets/...` (macOS/Linux). Nothing you set this way is
ever committed.

Environment variables work too, and are what you would use on a server — replace `:`
with `__`:

```powershell
$env:Jwt__Key = "REPLACE_WITH_A_LONG_RANDOM_SECRET_AT_LEAST_32_CHARS"
```

`Jwt:Issuer` and `Jwt:Audience` already have working defaults in `appsettings.json`.

## 3. Point at your SQL Server

The default connection string in `appsettings.json` uses LocalDB and needs no change if
you have it:

```
Server=(localdb)\mssqllocaldb;Database=VocabGridDb;Trusted_Connection=True;MultipleActiveResultSets=true
```

Using SQL Server Express or a named instance instead? Override it in user secrets — this
keeps your machine-specific server name out of the repository, so everyone can use a
different instance without editing tracked files:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=VocabGridDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true" --project src/LanGigaCards.Api
```

SQL authentication instead of Windows authentication:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=VocabGridDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;MultipleActiveResultSets=true" --project src/LanGigaCards.Api
```

`TrustServerCertificate=True` is needed for local instances using a self-signed
certificate. Do not carry it into production.

## 4. The database — nothing to do

**Skip this step.** In Development the app creates the database itself on first run and
applies any migration added since the last one. There is no script to execute, no backup
to restore, and nothing to attach in SSMS.

You will see it happen in the startup log:

```
info: LanGigaCards.Api[0] Applying 10 pending migration(s) to VocabGridDb.
info: Microsoft.EntityFrameworkCore.Migrations[20402] Applying migration '20260808183423_InitialCreate'.
...
info: LanGigaCards.Api[0] Database ready: VocabGridDb.
```

On later runs, with nothing pending, only the last line appears.

What you get is a fully populated database — 26 tables plus the seed content: 10
languages, 15 categories, 14 word tags, 6 learning purposes, 5 achievements, 20 lessons,
10 quizzes, 238 vocabulary entries and 312 word-to-tag links. No user accounts; you create
yours by registering in the app.

This is Development-only on purpose. In production a schema change should be a deliberate,
reviewed step, and two instances starting at once would race each other applying it —
so deploy with an explicit `dotnet ef database update` instead.

Want to apply migrations by hand anyway (needs the optional EF CLI):

```bash
dotnet ef database update --project src/LanGigaCards.Api
```

## 5. Email delivery (optional)

**Skip this and the API still works.** Without SMTP credentials the app registers a
logging stub instead of a real sender: verification codes and password-reset tokens are
written to the console rather than emailed, and in Development the
`send-verification-code` endpoint returns the code in its response as
`DevVerificationCode` so you can finish the flow from Swagger.

To send real mail, set all four values. `Smtp:Password` is absent from
`appsettings.json` on purpose — it belongs in user secrets only:

```bash
dotnet user-secrets set "Smtp:Host" "smtp.gmail.com" --project src/LanGigaCards.Api
dotnet user-secrets set "Smtp:User" "you@gmail.com" --project src/LanGigaCards.Api
dotnet user-secrets set "Smtp:FromAddress" "you@gmail.com" --project src/LanGigaCards.Api
dotnet user-secrets set "Smtp:Password" "your-16-char-app-password" --project src/LanGigaCards.Api
```

For Gmail, that password is **not** your account password. Turn on 2-Step Verification in
your Google account, then create an App Password under *Security → App passwords*; Google
gives you a 16-character string. Accounts without 2-Step Verification cannot create one.

`Smtp:Port` (587), `Smtp:EnableSsl` (true), and `Smtp:FromName` already have defaults in
`appsettings.json` that suit Gmail and most providers.

The transport is chosen from configuration, not from the environment, and the app says
which one it picked on the first line of its startup log:

```
Email transport: SMTP via smtp.gmail.com:587 as you@gmail.com.
Email transport: logging stub — no Smtp:Host/User/Password configured, so no mail will be sent.
```

If you configured SMTP and still see the second line, one of Host, User, or Password is
empty — all three are required to activate the real sender.

## 6. Run

```bash
dotnet run --project src/LanGigaCards.Api
```

Swagger UI: `http://localhost:5068/swagger`

## 7. Run the tests

```bash
dotnet test LanGigaCards.slnx
```

The suite boots the real API pipeline against a throwaway SQLite database — no SQL Server
instance and no configuration are needed. See
[architecture.md](architecture.md#testing) for why it is built that way.

---

## Troubleshooting

**`Jwt:Key yapılandırması eksik`** — step 2 was skipped, or the command was run without
`--project`. `dotnet user-secrets list --project src/LanGigaCards.Api` must resolve the
project file; run from elsewhere without the flag it reads a different (or missing)
secret store.

**`You must install or update .NET`** — no compatible runtime found. Install the .NET 8
SDK or newer.

**`A network-related or instance-specific error occurred`** — SQL Server is not running,
or the instance name in the connection string is wrong. Check which instances exist:

```powershell
Get-Service | Where-Object { $_.Name -like 'MSSQL*' }
```

**Verification email never arrives** — check the startup log line described in step 5.
The logging stub is silent by design.
