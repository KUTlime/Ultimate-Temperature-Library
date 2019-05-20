namespace UnitTestUltimateTemperatureLibrary
{
    /// <summary>
    /// Provides the test category strings used in attributes.
    /// </summary>
    /// <remarks>Members of this class should be used in unit test attributes.</remarks>
    public static class TestCategory
    {
        /// <summary>
        /// Provides a string name for a basic unit test category.
        /// </summary>
        /// <remarks>All basic or data driven tests should use this category.</remarks>
        public const string BasicTests = "Basic tests";

        /// <summary>
        /// Provides a string name for an integration test category.
        /// </summary>
        /// <remarks>All test which qualifies like an integration test should use this category.</remarks>
        public const string IntegrationTests = "Integration tests";
    }
}