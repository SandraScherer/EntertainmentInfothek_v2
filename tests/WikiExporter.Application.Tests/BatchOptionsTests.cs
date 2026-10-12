using WikiExporter.Application.Persistence;

namespace WikiExporter.Application.Tests;

/// <summary>Verifies that requested batch sizes are normalized to safe bounds.</summary>
public sealed class BatchOptionsTests
{
    [Fact]
    public void DefaultSize_IsTwoHundredAndFifty()
        => Assert.Equal(250, new BatchOptions().NormalizedSize);

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-10, 1)]
    [InlineData(1, 1)]
    [InlineData(250, 250)]
    [InlineData(10000, 10000)]
    [InlineData(10001, 10000)]
    [InlineData(int.MaxValue, 10000)]
    public void NormalizedSize_ClampsToSupportedRange(int requested, int expected)
        => Assert.Equal(expected, new BatchOptions(requested).NormalizedSize);
}
