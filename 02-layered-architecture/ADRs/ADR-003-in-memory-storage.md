# ADR-003: Use In-Memory Repository for Persistence

## Status
Accepted

## Context
The project needs a persistence mechanism for storing shortened URLs.  
However:
- The project is a learning/demo environment  
- No real database is required  
- We want fast tests and zero external dependencies

## Decision
We implement `IUrlRepository` using an **in-memory repository** backed by a thread-safe `ConcurrentDictionary`.

## Consequences
- No external services required  
- Fast and deterministic tests  
- Easy to replace with a real database later  
- Data is lost on application restart (acceptable for this variant)
