# Contributing

## Before you start

```bash
dotnet build LanGigaCards.slnx
dotnet test LanGigaCards.slnx
```

Both must be green on a fresh clone before you change anything. If they are not, that is
the bug to fix first.

## Branches

* `main` is the integration branch; do not commit to it directly.
* Branch names describe the work: `feature/<topic>`, `fix/<topic>`, `chore/<topic>`.
* Rebase on `main` before opening a pull request. Merge commits from `main` into a feature
  branch make the eventual review diff unreadable.

## Commits

Write the *why*, not the *what* — the diff already says what changed. A message that
explains the constraint you were working around is the one that saves the next person an
hour.

## Changing the model

There are no hand-written SQL scripts here; the schema is EF Core migrations.

```bash
dotnet ef migrations add DescriptiveName --project src/LanGigaCards.Api
```

Then:

1. **Read the generated migration.** EF guesses; it is sometimes wrong, particularly
   about column drops and renames, which it models as drop-and-recreate — silently losing
   data.
2. **Add the constraints.** New columns belong in `Data/SchemaConfiguration.cs` with a
   length bound and, where the DTO validates a range, a matching CHECK constraint. The
   table is the last line of defence, not the first.
3. **Check for drift**: `dotnet ef migrations has-pending-model-changes --project src/LanGigaCards.Api`
   must report no changes when you are done.
4. Never edit a migration that has already been merged. Add a new one.

## Tests

New endpoints need tests. The bar is not coverage percentage — it is that a reviewer can
see the rule enforced:

* Anything behind `[Authorize]` needs a test that an unauthenticated caller is rejected.
* Anything scoped to a user needs a test that a *second* account cannot see or change it.
* Logic in `Services/` should be tested directly, without a request.

Read [docs/architecture.md#testing](docs/architecture.md#testing) first — the SQLite
setup and the per-IP rate limits both have consequences for how you write a test.

## Style

`.editorconfig` is enforced at build time and CI builds with `-warnaserror`, so a style
violation fails the pipeline rather than reaching review. Run `dotnet build` before
pushing and the answer is immediate.

## Definition of done

* `dotnet build LanGigaCards.slnx` — no warnings
* `dotnet test LanGigaCards.slnx` — green
* New behaviour is covered by a test, and documented in `docs/` if a client needs to know
* No secret, connection string or key added to a tracked file
