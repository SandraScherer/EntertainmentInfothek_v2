// WikiExporter.Domain.dll: export read models and neutral domain contracts
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Domain.Export;

/// <summary>
/// Represents movie export data.
/// </summary>
public record MovieExportData(
    string Id,
    LocalizedValue Title,
    string? TypeId,
    string? Budget,
    string? WorldwideGross,
    string? WorldwideGrossDate,
    string? ConnectionId,
    string? Details,
    IReadOnlyList<ExportRowData> RelatedData)
    : ExportDataBase(
        Id,
        Title,
        Details,
        RelatedData);
