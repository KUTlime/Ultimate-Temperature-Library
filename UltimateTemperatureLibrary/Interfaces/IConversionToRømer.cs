namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Rømer scale convertible object.
    /// </summary>
    public interface IConversionToRømer
    {
        /// <summary>
        /// Returns temperature converted to the Rømer unit.
        /// </summary>
        /// <returns>A temperature converted to the Rømer unit.</returns>
        Rømer ToRømer();
    }
}