# ADR-001: Use Minimal API for the MVP

## Status
Accepted

## Context
We need a fast, simple implementation to establish the baseline functionality of the URL Shortener.

## Decision
Use .NET Minimal API with a single entry point.

## Rationale
- Minimal overhead
- Clear and readable
- Well suited for small HTTP services
- Easy to extend later if needed

## Consequences
- Limited built-in structure
- Not ideal for very large or complex applications
- Perfectly adequate for a small MVP and demo
