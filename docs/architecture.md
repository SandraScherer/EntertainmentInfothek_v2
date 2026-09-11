# WikiExporter Architektur

## Ziel

WikiExporter exportiert Inhalte aus einer bestehenden SQLite-Datenbank in Markdown-Dateien für:

- Obsidian
- DokuWiki

Die Anwendung wird zunächst als Konsolenanwendung umgesetzt und später um eine GUI erweitert.

---

# Architekturprinzipien

- Clean Architecture
- Dependency Injection
- Logging
- Testbarkeit
- Trennung von Datenzugriff und Fachlogik
- Erweiterbarkeit für weitere Exportformate

---

# Lösungsstruktur

```text
WikiExporter

src
│
├── WikiExporter.Console
│
├── WikiExporter.Application
│
├── WikiExporter.Domain
│
├── WikiExporter.Infrastructure
│
└── WikiExporter.Markdown

tests
│
├── WikiExporter.Application.Tests
│
├── WikiExporter.Infrastructure.Tests
│
└── WikiExporter.Markdown.Tests
```

---

# Layer

## Domain

Zentrale Fachobjekte.

Verantwortlichkeiten:
- Entities
- Value Objects
- Business Rules

Keine Referenzen auf:
- EF Core
- SQLite
- FileSystem
- Console

---

## Application

Geschäftslogik.

Verantwortlichkeiten:
- DTOs
- Use Cases
- Builder
- Validatoren
- Interfaces

Beispiele:
- ExportMovieUseCase
- MovieExportDto
- ExportDocument

---

## Infrastructure

Technische Implementierungen.

Verantwortlichkeiten:
- SQLite
- EF Core
- Repositorys
- FileWriter

Beispiele:
- EntertainmentInfothekDbContext
- MovieRepository
- FileWriter

---

## Markdown

Renderer für verschiedene Zielformate.

Verantwortlichkeiten:
- ObsidianRenderer
- DokuWikiRenderer

Markdown kennt keine Datenbankobjekte.

---

## Console

Benutzerschnittstelle.

Verantwortlichkeiten:
- Menüs
- Benutzereingaben
- Starten von UseCases

---

# Dependency Rule

Abhängigkeiten zeigen immer nach innen.

```text
Console

    ↓

Application

    ↓

Domain
```

Infrastructure und Markdown implementieren lediglich Interfaces aus Application.

---

# Movie Vertical Slice

```text
Program

    ↓

ExportMovieUseCase

    ↓

MovieRepository

    ↓

MovieExportDto

    ↓

MovieExportDocumentBuilder

    ↓

ExportDocument

    ↓

Renderer

    ↓

Markdown

    ↓

FileWriter

    ↓

Datei
```

---

# Erweiterbarkeit

Neue Exporttypen:
- Series
- Episode
- Person
- VideoGame
- Book

Neue Ausgabeformate:
- HTML
- PDF
- MkDocs
- Confluence

können ohne Änderungen an der bestehenden Architektur ergänzt werden.
