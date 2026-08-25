# Configuration reference

| Key | Required | Where it belongs | Default |
| --- | --- | --- | --- |
| `Jwt:Key` | **Yes** | User secrets / environment | none — startup fails without it |
| `Jwt:Issuer` | No | `appsettings.json` | `VocabGridAPI` |
| `Jwt:Audience` | No | `appsettings.json` | `VocabGridApp` |
| `ConnectionStrings:DefaultConnection` | No | `appsettings.json`, override in user secrets | LocalDB, database `VocabGridDb` |
| `Smtp:Host` | No | User secrets | empty → logging stub |
| `Smtp:User` | No | User secrets | empty → logging stub |
| `Smtp:Password` | No | **User secrets only** | empty → logging stub |
| `Smtp:FromAddress` | No | User secrets | empty |
| `Smtp:Port` | No | `appsettings.json` | `587` |
| `Smtp:EnableSsl` | No | `appsettings.json` | `true` |
| `Smtp:FromName` | No | `appsettings.json` | `LanGigaCards` |
| `Cors:AllowedOrigins` | Production | Environment / secret store | empty — Development allows any origin |
| `Authentication:Google:ClientId` | For Google sign-in | User secrets | empty |
| `Authentication:Apple:ClientId` | For Apple sign-in | User secrets | empty |

In environment variables, `:` becomes `__` — `Jwt:Key` is `Jwt__Key`,
`Smtp:Password` is `Smtp__Password`.

## Why three defaults still say "VocabGrid"

The project was renamed from VocabGrid to LanGigaCards. Code identity moved with it —
namespaces, assembly, product name. Three values deliberately did not, because they are
runtime identifiers rather than code identity, and changing them breaks environments that
already work:

* **`UserSecretsId`** (`f07a094b-…` in the csproj) — every contributor's `Jwt:Key` and
  SMTP credentials are already filed under this id. A new one would hide them, and the
  API would refuse to start with a confusing "key missing" error on a machine where the
  key was set months ago.
* **`Database=VocabGridDb`** — renaming it means every contributor's local database is
  suddenly the wrong one, to be recreated and re-seeded from scratch.
* **`Jwt:Issuer` / `Jwt:Audience`** — these are validated on every request. Changing them
  invalidates every token already issued to a running client build, logging everyone out
  with no explanation.

None of them is user-visible. Rename them, if ever, as a deliberate migration with a
coordinated client release — not as a side effect of tidying a folder structure.
