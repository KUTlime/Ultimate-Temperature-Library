namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToDelisle
    {
        Delisle ToDelisle();
        double ToDelisle(TemperatureUnit temperatureUnit);
        double ToDelisle(double value);
    }
}