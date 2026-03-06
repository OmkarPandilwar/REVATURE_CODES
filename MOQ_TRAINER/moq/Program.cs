using System;
using System.Collections.Generic;

// ================== Interface ==================
public interface IWeatherService
{
    IEnumerable<double> GetTemperature(string city);
}

// ================== Real Service ==================
public class WeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        // For now, don't throw, just return some data
        // throw new Exception("City not found");

        yield return 20;
        yield return 21;
    }
}

// ================== Mock Service ==================
public class MockWeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        yield return 20;
        yield return 21;
        yield return 22;
        yield return 23;
        yield return 24;
    }
}

// ================== ENTRY POINT ==================
public class Program
{
    public static void Main(string[] args)
    {
        // Choose which service to use:
        //IWeatherService service = new WeatherService();
        IWeatherService service = new MockWeatherService();

        Console.WriteLine("Temperatures:");

        foreach (var t in service.GetTemperature("Pune"))
        {
            Console.WriteLine(t);
        }
    }
}