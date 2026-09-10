using WikiExporter.Domain.Export;

namespace WikiExporter.Domain.Tests;

public sealed class ExportModelsTests
{
    [Fact]
    public void LocalizedValue_RetainsAllLanguageVariants()
    {
        var value = new LocalizedValue("Original", "English", "Deutsch");
        Assert.Equal("Original", value.Original);
        Assert.Equal("English", value.English);
        Assert.Equal("Deutsch", value.German);
    }

    [Fact]
    public void ExportRowData_RetainsFieldsAndForeignKeys()
    {
        var row = new ExportRowData("Movie_Cast", "cast-1",
            new Dictionary<string, string?> { ["EnglishRole"] = "Hero" },
            new Dictionary<string, string?> { ["ActorID"] = "person-1" }, "10");

        Assert.Equal("Hero", row.Fields["EnglishRole"]);
        Assert.Equal("person-1", row.ForeignKeys["ActorID"]);
        Assert.Equal("10", row.Order);
    }
}
