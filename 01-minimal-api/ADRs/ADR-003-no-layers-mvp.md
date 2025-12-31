# ADR-003: Avoid Layered Architecture in the MVP

## Status
Accepted

## Context
The initial version of the URL Shortener is intentionally small and simple. Introducing a full layered architecture may add more ceremony than value at this stage.

## Decision
Do not introduce a full layered architecture (e.g., separate projects for API, Application, Domain, Infrastructure) in the MVP. Use folders and a small number of services instead.

## Rationale
- Avoid premature complexity
- Keep the implementation approachable and easy to read
- Focus on delivering value quickly
- Still allow for clear responsibilities (API, Application, Infrastructure) via namespaces and directories

## Consequences
- Some refactoring may be required if the service grows significantly
- Fewer boundaries are enforced by the project structure
- For the scale of this MVP, the trade-off is acceptable
