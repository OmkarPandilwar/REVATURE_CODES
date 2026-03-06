using System.Linq;
using Xunit;

public class WeatherServiceTests
{
    [Fact]
    public void MockWeatherService_Should_Return_5_Temperatures()
    {
        // Arrange
        IWeatherService service = new MockWeatherService();

        // Act
        var temps = service.GetTemperature("Pune").ToList();

        // Assert
        Assert.Equal(5, temps.Count);
        Assert.Equal(20, temps[0]);
        Assert.Equal(24, temps[4]);
    }
}