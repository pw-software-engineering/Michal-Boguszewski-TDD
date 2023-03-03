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

    [Theory]
    [InlineData("2,3", 5)]
    [InlineData("-2,-3", -5)]
    [InlineData("0,3", 3)]
    [InlineData("-123,124", 1)]
    [InlineData("-123,123", 0)]
    public void AddTest_InputIsTwoNumbersDividedByComma_ReturnsTheirSum(string input, int expected)
    {
        var actual = calculator.Add(input);

        actual.Should().Be(expected);
    }
}
