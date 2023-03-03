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
    [InlineData(123)]
    [InlineData(int.MaxValue)]
    public void AddTest_InputIsSingleNumber_ReturnsInput(int expected)
    {
        var actual = calculator.Add(expected.ToString());

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("2,3", 5)]
    [InlineData("0,3", 3)]
    [InlineData("123,124", 127)]
    public void AddTest_InputIsTwoNumbersDividedByComma_ReturnsTheirSum(string input, int expected)
    {
        var actual = calculator.Add(input);

        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("2\n3", 5)]
    [InlineData("0\n3", 3)]
    [InlineData("123\n124", 247)]
    public void AddTest_InputIsTwoNumbersDividedByNewLina_ReturnsTheirSum(string input, int expected)
    {
        var actual = calculator.Add(input);

        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("2\n3,4", 9)]
    [InlineData("2,3\n4", 9)]
    [InlineData("5\n3,4", 12)]
    public void AddTest_InputIsThreeNumbersDividedByCommaOrNewLine_ReturnsTheirSum(string input, int expected)
    {
        var actual = calculator.Add(input);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("-1\n2")]
    public void AddTest_InputContainsNegativeNumber_ThrowArgumentOutOfRangeException(string input)
    {
        var func = () => calculator.Add(input);

        func.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData("1\n2,1001", 3)]
    public void AddTest_InputContainsNumbersGreaterThan1000_IgnoreThoseNumbers(string input, int expected)
    {
        var actual = calculator.Add(input);

        actual.Should().Be(expected);
    }
}
