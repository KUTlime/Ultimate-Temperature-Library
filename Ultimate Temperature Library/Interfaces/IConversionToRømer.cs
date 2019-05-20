namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToRømer
    {
        Rømer ToRømer();

        double ToRømer(TemperatureUnit temperatureUnit);

        double ToRømer(double value);
    }
}