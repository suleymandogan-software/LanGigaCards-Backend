## What and why

<!-- What changed, and what problem it solves. The diff shows the what; this is for the why. -->

## How to verify

<!-- The steps a reviewer takes to see it work: endpoint, request, expected response. -->

## Checklist

- [ ] `dotnet build LanGigaCards.slnx` is clean — no warnings
- [ ] `dotnet test LanGigaCards.slnx` is green
- [ ] New or changed behaviour has a test
- [ ] Model changes have a migration, with the new columns bounded and constrained in `SchemaConfiguration.cs`
- [ ] `dotnet ef migrations has-pending-model-changes` reports no drift
- [ ] No secret, key or connection string added to a tracked file
- [ ] `docs/api/openapi.json` regenerated if a route or DTO changed
- [ ] `docs/` updated if a client needs to know about this
