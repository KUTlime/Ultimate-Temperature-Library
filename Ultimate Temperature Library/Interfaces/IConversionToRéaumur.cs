namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToRéaumur
    {
        Réaumur ToRéaumur();
        double ToRéaumur(TemperatureUnit temperatureUnit);
        double ToRéaumur(double value);
    }
}