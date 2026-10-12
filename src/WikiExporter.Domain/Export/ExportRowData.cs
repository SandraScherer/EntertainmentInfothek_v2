// WikiExporter.Domain.dll: export read models and neutral domain contracts
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Domain.Export;

/// <summary>
/// One persisted row retained by the export read model.
/// This prevents data loss for schema areas not yet given a specialized domain type.
/// </summary>
public record ExportRowData(
    string Table,
    string Id,
    IReadOnlyDictionary<string, string?> Fields,
    IReadOnlyDictionary<string, string?> ForeignKeys,
    string? Order = null);
