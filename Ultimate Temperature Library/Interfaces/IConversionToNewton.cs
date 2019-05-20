namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToNewton
    {
        Newton ToNewton();
        double ToNewton(TemperatureUnit temperatureUnit);
        double ToNewton(double value);
    }
}