using Xunit;
using MyApp;

public class CalculatorTests
{
    [Fact]
    public void Add_ReturnsCorrectResult()
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        int result = calc.Add(5, 10);

        // ASSERT
        Assert.Equal(15, result);
    }
}