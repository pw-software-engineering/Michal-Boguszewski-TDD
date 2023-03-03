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

    [Fact]
    public void AddTest_InputIsSingleNumber_ReturnsInput()
    {
        int expected = 4;
        var actual = calculator.Add(expected.ToString());

        actual.Should().Be(expected);
    }
}
