# Dokumentationsprüfung

Diese Revision prüft XML-Kommentare und Architekturdokumentation auf Vollständigkeit und Verständlichkeit.

- Ergänzt wurden fehlende XML-Kommentare an den beiden Persistence-Konstruktoren, am Konstruktor des DocumentBuilderResolver und an den beiden Partial-Deklarationen von `ExportScope`.
- `ARCHITECTURE.md` dokumentiert Schichten, Abhängigkeitsrichtung, Exportablauf, Daten-/Referenzmodell, Sprachfallback, EF-Core-Abfrageansatz, Dateistruktur und Testprojekte.
- `README.md` verweist auf die Architekturdetails.
- Der XML-Kommentarstandard bleibt `/// <summary>`, ergänzt durch `<param>` bei Konstruktoren/Methoden, wo Parameter erklärt werden müssen.

Hinweis: Die Codebasis enthält zahlreiche automatisch erzeugte Kurzkommentare mit eher allgemeiner Formulierung. Die wichtigsten Architektur- und Ablaufentscheidungen sind nun separat präzisiert; eine manuelle fachliche Beschreibung jedes einzelnen Datenbankfelds erfordert zusätzliche Schema-/Domänenkenntnis und sollte nicht durch erfundene Semantik ersetzt werden.
