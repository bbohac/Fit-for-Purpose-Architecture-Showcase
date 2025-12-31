# 01 - Minimal API URL Shortener

This variant implements a simple URL Shortener using:

- .NET 10 Minimal API
- In-memory storage
- A small application service for URL shortening logic
- Unit tests following the pattern MethodName_StateUnderTest_ExpectedBehavior
- Architecture Decision Records (ADRs) for key decisions

---

## Run locally

dotnet run --project 01-minimal-api/src/MinimalApi.csproj

---

## Endpoints

### POST /shorten

Creates a shortened URL.

#### Request body
```json

{
  "url": "https://example.com"
}
```

#### Example curl request
```plaintext
curl -X POST http://localhost:5000/shorten \
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

### GET /{code}

Redirects to the original URL.

#### Example curl request
```plaintext
curl -I http://localhost:5000/abc123ef
```

#### Example response
```plaintext
HTTP/1.1 302 Found  
Location: https://example.com
```

(Using `-I` shows only headers, which is useful for redirects.)