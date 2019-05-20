namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToFahrenheit
    {
        Fahrenheit ToFahrenheit();
        double ToFahrenheit(TemperatureUnit temperatureUnit);
        double ToFahrenheit(double value);
    }
}