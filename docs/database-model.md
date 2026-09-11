# Datenbankmodell

## Überblick

Die SQLite-Datenbank stellt eine Entertainment-Datenbank dar.

Sie enthält:
- Filme
- Serien
- Episoden
- Bücher
- Veröffentlichungen
- Videospiele
- Personen
- Firmen
- Auszeichnungen

Die meisten Tabellen verwenden:

```sql
ID TEXT PRIMARY KEY
```

---

# Hauptaggregate

## Movie

Film.

Verknüpfte Daten:
- Genre
- Cast
- Crew
- Bilder
- Texte
- Weblinks
- Auszeichnungen

## Series

Serie.

Verknüpfte Daten:
- Episoden
- Cast
- Crew
- Texte
- Bilder

## Episode

Episode einer Serie.

Verknüpfte Daten:
- Cast
- Crew
- Texte
- Bilder

## Book

Werk oder Buch.

Verknüpfte Daten:
- Veröffentlichungen
- Genre
- Texte
- Bilder

## Publication

Konkrete Veröffentlichung eines Buches.

Beispiele:
- Taschenbuch
- Hardcover

## VideoGame

Videospiel.

Verknüpfte Daten:
- Plattformen
- Versionen
- Technische Daten
- Genre
- Texte

## Person

Person.

Verknüpfte Daten:
- Berufe
- Arbeitgeber
- Familie
- Texte

---

# Lookup Tabellen

## Genre

Kategorisierung.

Beispiele:
- Action
- Science Fiction
- Adventure

## Language

Sprachen.

Beispiele:
- Deutsch
- Englisch

## Status

Statusinformationen.

## Department

Crew-Abteilungen.

Beispiele:
- Directing
- Writing
- Production

## TextType

Beschreibung des Textes.

Beispiele:
- Synopsis
- Plot
- Biography

## ImageType

Bildtyp.

Beispiele:
- Poster
- Cover
- Screenshot

---

# Join Tabellen

Die Datenbank verwendet überwiegend M:N Tabellen.

Beispiele:

## Movie

```text
Movie_Genre
Movie_Cast
Movie_Crew
Movie_Text
Movie_Image
Movie_Weblink
```

## Series

```text
Series_Genre
Series_Cast
Series_Crew
Series_Text
Series_Image
Series_Weblink
```

## VideoGame

```text
VideoGame_Genre
VideoGame_Text
VideoGame_Image
VideoGame_Version
```

---

# Exportrelevante Movie Tabellen

Für den ersten Vertical Slice werden folgende Tabellen verwendet:

```text
Movie

Movie_Genre
Genre

Movie_Cast
Person

Movie_Crew
Person
Department

Movie_Text
Text
TextType

Movie_Image
Image

Movie_Weblink
Weblink

Status
```
