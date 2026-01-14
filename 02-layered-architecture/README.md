# 02 - Layered Architecture URL Shortener
This variant implements a simple URL Shortener using a classic layered architecture with clear separation of concerns:

- ASP.NET Core 10 Web API (Controller-based)
- Application layer containing business logic
- Domain layer with core entities
- Infrastructure layer with an in-memory repository
- Unit tests for Application and Infrastructure layers
- Architecture Decision Records (ADRs) for key decisions

---

## Run locally

```plaintext
dotnet run --project 02-layered-architecture/src/Api/Api.csproj
```
The API will start with Swagger enabled in Development mode.

---

## Endpoints

### POST /shortener/shorten

Creates a shortened URL.

#### Request body
```json
{
  "url": "https://example.com"
}
```

#### Example curl request
```plaintext
curl -X POST https://localhost:5001/shortener/shorten \
     -H "Content-Type: application/json" \
     -d '{ "url": "https://example.com" }'
```

#### Example response
```json
{
  "code": "abc123ef",
  "url": "https://example.com"
}
```
---

### GET /shortener/{code}
Resolves a short code and redirects to the original URL.

Important:  
Swagger cannot follow browser redirects and will show “Failed to fetch”.  
Use a browser or curl instead.

#### Example curl request
```plaintext
curl -I https://localhost:5001/shortener/abc123ef
```
#### Example response
```plaintext
HTTP/1.1 302 Found
Location: https://example.com
```

(Using `-I` shows only headers, which is useful for redirects.)

---

## Architecture Overview

This variant follows a strict layered architecture:

- **API Layer**  
  Controllers, request/response records, no business logic.

- **Application Layer**  
  Business logic, URL validation, repository abstraction.

- **Domain Layer**  
  Core entity `ShortUrl` (sealed class).

- **Infrastructure Layer**  
  In-memory implementation of `IUrlRepository`.

Each layer is independently testable and has a single responsibility.

---

## Tests

This variant includes:
- **Application.Tests**  
  Tests for `ShorteningService`  
  Pattern: `MethodName_StateUnderTest_ExpectedBehavior`
- **Infrastructure.Tests**  
  Tests for `InMemoryUrlRepository`

All tests run without external dependencies.

---

## ADRs
This variant includes Architecture Decision Records explaining:

- Why a layered architecture was chosen
- Why controllers instead of minimal APIs
- Why an in-memory repository is used
- Why sealed classes and records are used where appropriate

---

## Summary
Variant 2 demonstrates a clean, maintainable layered architecture with:
- Clear separation of concerns
- Testable components
- Simple extensibility
- A straightforward URL shortener implementation

It serves as a solid foundation for more complex systems.
