# API notes

Swagger UI is the live reference: `http://localhost:5068/swagger` in Development. This
page covers only the parts a client gets wrong without being told.

[`openapi.json`](api/openapi.json) is the same document, checked in so the client
contract shows up in a diff when it changes. Regenerate it after changing any route or
DTO — CI fails if the committed copy has drifted:

```bash
dotnet tool restore
dotnet build src/LanGigaCards.Api -c Release
dotnet swagger tofile --output docs/api/openapi.json \
  src/LanGigaCards.Api/bin/Release/net8.0/LanGigaCards.Api.dll v1
```

## Auth endpoints

`POST /api/Auth/register` — all fields are required, `confirmPassword` must match, and
the password must be at least 8 characters. Registration also issues a verification code.

```json
{
  "firstName": "Ekin",
  "lastName": "Adsay",
  "email": "ekin@example.com",
  "password": "Test1234!",
  "confirmPassword": "Test1234!"
}
```

`POST /api/Auth/send-verification-code` — `{ "email": "..." }`. Issues a fresh 6-digit
code and retires any outstanding one. In Development the response includes
`DevVerificationCode`.

`POST /api/Auth/verify-email` — `{ "email": "...", "code": "123456" }`. Codes expire
after 15 minutes and allow 5 attempts before requiring a new one.

`POST /api/Auth/refresh` — refresh tokens **rotate**. Each redemption revokes the token
it was called with, so a client must store the new one from the response. Replaying a
spent token returns 401; the revoked row is kept rather than deleted, because a replay is
the signal that the token was stolen.

Other endpoints: `login`, `forgot-password`, `reset-password`, `google`, `apple`.

Email verification is **not** a login gate — an unverified user can still sign in, and
the auth response carries `isEmailVerified` so the client can decide what to do about it.

Rate limits are per client IP: 5 requests / 5 minutes on login, 10 / 15 minutes on
register, forgot-password and the code-sending endpoints. Over the limit the API answers
429 with no body.

## Catalog and statistics endpoints

`GET /api/Language` — the supported languages, ordered for a picker. **Anonymous**: the
sign-up and onboarding screens need this list before the user has a session. Add
`?includeInactive=true` to see languages that have been switched off.

`GET /api/Tag` — word tags, optionally filtered with `?kind=Grammar|Register|Difficulty`.
Tags describe a word's grammar or usage ("irregular verb", "formal", "false friend") and
are separate from categories, which are topics the learner picks as interests.

`GET /api/Tag/{slug}/words` — words carrying a tag. Returns curriculum words plus the
caller's own cards; another user's cards never appear, even when they share the tag.

`GET /api/Progress/daily-summary?from=&to=` — one row per day of study, defaulting to the
last year. Backed by a rollup table rather than a scan over raw activity, so the heatmap
reads at most 365 rows instead of every review the user has ever done. Days with no study
have no row — the client draws the gap as "no activity" rather than a zero.

## Ownership rules

Deck and card endpoints are scoped to the caller. Asking for another account's deck
returns **404, not 403** — a 403 would confirm the deck exists. `DeckEndpointsTests`
pins this down so a future refactor cannot quietly turn it into an existence oracle.

## Flutter / client notes

* Android emulator base URL: `http://10.0.2.2:5068` (`localhost` inside the emulator is
  the emulator itself)
* Chrome / Windows: `http://localhost:5068`
* Achievements: `GET /api/Achievements` (there is no `/api/Badges`)
* Decks/cards: `/api/Deck`, `/api/Flashcard`
* Profile language codes: `nativeLanguageCode` / `targetLanguageCode` (e.g. `en`, `tr`)
* Learning purposes: `PUT /api/User/learning-purposes` expects `{ "learningPurposeIds": [...] }`.
  A different key name binds to nothing and silently clears the user's saved purposes.
* Categories include `iconName` and `colorHex`
* Language list: `GET /api/Language` — prefer this over a hardcoded client list. `flagCode`
  is separate from `code` because they differ (`en`→`gb`, `ja`→`jp`, `ko`→`kr`, `zh`→`cn`)
* Seed word IDs live in reserved ranges (1001–1118 and 5001–5120); cards created through
  the API start at 10001, so the two never collide
* Development CORS is open; production must set `Cors:AllowedOrigins`

The client that consumes this API lives in
[LanGigaCards1](https://github.com/suleymandogan-software/LanGigaCards1).
