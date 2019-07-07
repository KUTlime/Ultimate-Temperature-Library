namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Delisle scale convertible object.
    /// </summary>
    public interface IConversionToDelisle
    {
        /// <summary>
        /// Returns temperature converted to the Delisle unit.
        /// </summary>
        /// <returns>A temperature converted to the Delisle unit.</returns>
        Delisle ToDelisle();
    }
}