using FluentAssertions;
using Source;

namespace Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator calculator = new();
    
    [Fact]
    public void AddTest_InputIsEmpty_ReturnsZero()
    {
        var result = calculator.Add("");

        result.Should().Be(0);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(-4)]
    [InlineData(123)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void AddTest_InputIsSingleNumber_ReturnsInput(int expected)
    {
        var actual = calculator.Add(expected.ToString());

        actual.Should().Be(expected);
    }
}
