namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Rankine scale convertible object.
    /// </summary>
    public interface IConversionToRankine
    {
        /// <summary>
        /// Returns temperature converted to the Rankine unit.
        /// </summary>
        /// <returns>A temperature converted to the Rankine unit.</returns>
        Rankine ToRankine();
    }
}