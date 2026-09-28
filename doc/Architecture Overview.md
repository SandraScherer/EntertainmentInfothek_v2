# Architecture Overview

# Architectural Principles

- Clean Architecture
- Dependency Injection
- Logging
- Testability
- Separation of Data Access and Business Logic
- Extensibility for additional export formats


## Structure

```text
WikiExporter

src
│
├── WikiExporter.Console
│
├── WikiExporter.Application
│
└── WikiExporter.Persistence

tests
│
├── WikiExporter.Console.Test
│
├── WikiExporter.Application.Test
│
└── WikiExporter.Persistence.Test
```


## Layer

### Console

User Interface.

Responsibilities:
- Menus
- User Inputs
- Starting Use Cases


## Application

Business logic.

Responsibilities:
- Use Cases

Examples:
- ...


## Persistence

Key Specialized Properties.

Responsibilities:
- SQLite
- EF Core
- Entities

Examples:
- EntertainmentInfothekDbContext

