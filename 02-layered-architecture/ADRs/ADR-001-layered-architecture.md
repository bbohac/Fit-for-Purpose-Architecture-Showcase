# ADR-001: Choose Layered Architecture

## Status
Accepted

## Context
The project requires a clean, maintainable structure that separates concerns clearly.  
The system is simple, but should still demonstrate how a scalable architecture can be organized.  
We want:
- testable business logic
- clear boundaries between layers
- no infrastructure leaking into the domain or application logic
- a structure that can grow into a more complex system

## Decision
We use a classic layered architecture with the following layers:

- **API Layer**: HTTP controllers, request/response models  
- **Application Layer**: business logic, URL validation, repository abstraction  
- **Domain Layer**: core entities, pure domain logic  
- **Infrastructure Layer**: persistence implementation (in-memory for now)

Dependencies flow inward:
API → Application → Domain  
Infrastructure → Domain

## Consequences
- Clear separation of concerns  
- Easy to test each layer independently  
- Infrastructure can be replaced without touching business logic  
- Slightly more boilerplate than a minimal API, but more maintainable long-term
