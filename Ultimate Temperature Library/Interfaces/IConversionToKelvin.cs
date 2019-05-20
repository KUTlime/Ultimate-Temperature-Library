namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToKelvin
    {
        Kelvin ToKelvin();
        double ToKelvin(TemperatureUnit temperatureUnit);
        double ToKelvin(double value);
    }
}