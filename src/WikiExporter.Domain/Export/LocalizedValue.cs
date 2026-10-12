// WikiExporter.Domain.dll: export read models and neutral domain contracts
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Domain.Export;

/// <summary>
/// Localized source value.
/// Persistence keeps all three source-language variants.
/// </summary>
public record LocalizedValue(
    string? Original,
    string? English,
    string? German);
