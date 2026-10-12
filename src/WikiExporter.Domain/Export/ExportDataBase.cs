// WikiExporter.Domain.dll: export read models and neutral domain contracts
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Domain.Export;

/// <summary
/// >Represents export data base.
/// </summary>
public abstract record ExportDataBase(
    string Id,
    LocalizedValue Title,
    string? Details,
    IReadOnlyList<ExportRowData> RelatedData);
