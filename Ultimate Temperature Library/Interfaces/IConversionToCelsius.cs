namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToCelsius
    {
        Celsius ToCelsius();
        double ToCelsius(TemperatureUnit temperatureUnit);
        double ToCelsius(double value);
    }
}