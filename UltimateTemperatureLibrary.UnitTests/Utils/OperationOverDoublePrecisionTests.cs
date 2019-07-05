using Microsoft.VisualStudio.TestTools.UnitTesting;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests.Utils
{
    public class OperationOverDoublePrecisionTests
    {
        [TestClass]
        public class HighPrecisionTests
        {
            [TestMethod]
            public void HighPrecisionStandard()
            {
                // Arrange

                // Act

                // Assert
                Assert.AreEqual(1e-13, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class MiddlePrecisionTests
        {
            [TestMethod]
            public void MiddlePrecisionStandard()
            {
                // Arrange

                // Act

                // Assert
                Assert.AreEqual(1e-12, OperationOverDoublePrecision.MiddlePrecision);
            }
        }
    }
}
