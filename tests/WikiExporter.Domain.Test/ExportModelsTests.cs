using System;
using System.Collections.Generic;
using System.Text;
using WikiExporter.Domain.Export;

namespace WikiExporter.Domain.Test;

/// <summary>
/// Represents export models tests.
/// </summary>
[TestClass]
public class ExportModelsTests
{
    [TestMethod]
    public void LocalizedValue_RetainsAllLanguageVariants()
    {
        var value = new LocalizedValue("Original", "English", "Deutsch");
        Assert.AreEqual("Original", value.Original);
        Assert.AreEqual("English", value.English);
        Assert.AreEqual("Deutsch", value.German);
    }

    [TestMethod]
    public void ExportRowData_RetainsFieldsAndForeignKeys()
    {
        var row = new ExportRowData("Movie_Cast", "cast-1",
            new Dictionary<string, string?> { ["EnglishRole"] = "Hero" },
            new Dictionary<string, string?> { ["ActorID"] = "person-1" }, "10");

        Assert.AreEqual("Hero", row.Fields["EnglishRole"]);
        Assert.AreEqual("person-1", row.ForeignKeys["ActorID"]);
        Assert.AreEqual("10", row.Order);
    }
}
