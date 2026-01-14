# ADR-002: Use Controllers Instead of Minimal APIs

## Status
Accepted

## Context
ASP.NET Core offers two main approaches for building HTTP endpoints:
- Minimal APIs
- Controller-based APIs

Minimal APIs are concise and ideal for small services, but they mix routing, validation, and logic more easily.  
For a layered architecture, we want:
- explicit separation between API and application logic
- clear request/response models
- a structure that scales well as endpoints grow

## Decision
We use **controller-based APIs** instead of minimal APIs.

## Consequences
- Better alignment with layered architecture principles  
- Clearer separation between HTTP concerns and business logic  
- Slightly more ceremony, but more structure  
- Easier to extend with filters, attributes, and conventions
