# Export Flow

## Übersicht

Der Exportprozess besteht aus mehreren Schritten.

```text

SQLite

    ↓

EF Core

    ↓

Repository

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

# Schritt 1

Movie auswählen

Der Benutzer wählt:
- Datensatz
- Exportsprache
- Ausgabeformat

Beispiel:

```text
Movie = _xxx
Language = de-DE
Format = Obsidian
```

---

# Schritt 2

Repository

Lädt den Datensatz.

Ergebnis:

```text
MovieExportDto
```

Enthält:
- Titel
- Genres
- Cast
- Crew
- Texte
- Bilder
- Weblinks

---

# Schritt 3

Validierung

Prüfungen:

- Datensatz vorhanden
- Titel vorhanden
- ExportRequest gültig

Fehler:

- MovieNotFoundException
- ValidationException

---

# Schritt 4

Document Builder

Umwandlung:

```text
MovieExportDto

↓

ExportDocument
```

Sections:

```text
Allgemein
Genres
Handlung
Besetzung
Crew
Bilder
Weblinks
```

---

# Schritt 5

Renderer

Je nach Format wird ein Renderer gewählt.

## Obsidian

```markdown
# The Matrix
```

---

## DokuWiki

```dokuwiki
====== The Matrix ======
```

---

# Schritt 6

Datei schreiben

Dateiname:

```text
the-matrix.md
```

oder
```text
the-matrix.txt
```

Ausgabeordner:

```text
Exports/
```

---

# Fehlerbehandlung

## Request Validation

Prüft:

- Movie ID
- Sprache
- Zielordner

---

## DTO Validation

Prüft:

- Titel vorhanden

---

## Repository Validation

Prüft:

- Datensatz existiert

---

## File Validation

Prüft:

- Schreibrechte
- Dateisystemfehler

---

# Logging

Wichtige Events:

```text
Export started
Movie loaded
Document built
Markdown rendered
File written
Export completed
```

Fehler:

```text
Movie not found
Validation failed
Renderer failed
FileWriter failed
```

---

# Ergebnis

Die erzeugte Markdown-Datei ist vollständig von:

- SQLite
- EF Core
- Repositorys

entkoppelt.

Der Renderer arbeitet ausschließlich auf:

```text
ExportDocument
```

und kann deshalb später leicht für weitere Formate erweitert werden.
