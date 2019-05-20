namespace UltimateTemperatureLibrary.Interfaces
{
    public interface IConversionToRankine
    {
        Rankine ToRankine();
        double ToRankine(TemperatureUnit temperatureUnit);
        double ToRankine(double value);
    }
}