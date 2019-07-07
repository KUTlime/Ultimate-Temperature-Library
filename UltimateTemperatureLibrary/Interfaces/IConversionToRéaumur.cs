namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Réaumur scale convertible object.
    /// </summary>
    public interface IConversionToRéaumur
    {
        /// <summary>
        /// Returns temperature converted to the Réaumur unit.
        /// </summary>
        /// <returns>A temperature converted to the Réaumur unit.</returns>
        Réaumur ToRéaumur();
    }
}