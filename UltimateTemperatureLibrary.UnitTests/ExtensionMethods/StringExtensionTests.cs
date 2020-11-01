using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.ExtensionMethods;

namespace UltimateTemperatureLibrary.UnitTests.ExtensionMethods
{
	public class StringExtensionTests
	{
		[TestClass]
		public class RemoveAllWhiteSpacesMethodTests
		{

			[DataTestMethod]
			[DataRow((UInt32) 1, "", "")]
			[DataRow((UInt32) 2, " ", "")]
			[DataRow((UInt32) 3, "  ", "")]
			[DataRow((UInt32) 4, "   ", "")]
			[DataRow((UInt32) 5, " JanNovák", "JanNovák")]
			[DataRow((UInt32) 6, "  JanNovák", "JanNovák")]
			[DataRow((UInt32) 7, "   JanNovák", "JanNovák")]
			[DataRow((UInt32) 8, "JanNovák ", "JanNovák")]
			[DataRow((UInt32) 9, "JanNovák  ", "JanNovák")]
			[DataRow((UInt32) 10, "JanNovák   ", "JanNovák")]
			[DataRow((UInt32) 11, " JanNovák ", "JanNovák")]
			[DataRow((UInt32) 12, "  JanNovák ", "JanNovák")]
			[DataRow((UInt32) 13, "  JanNovák  ", "JanNovák")]
			[DataRow((UInt32) 14, "   JanNovák  ", "JanNovák")]
			[DataRow((UInt32) 15, "   JanNovák   ", "JanNovák")]
			[DataRow((UInt32) 16, " a", "a")]
			[DataRow((UInt32) 17, "  a", "a")]
			[DataRow((UInt32) 18, "   a", "a")]
			[DataRow((UInt32) 19, "a ", "a")]
			[DataRow((UInt32) 20, "a  ", "a")]
			[DataRow((UInt32) 21, "a   ", "a")]
			[DataRow((UInt32) 22, " a ", "a")]
			[DataRow((UInt32) 23, "  a ", "a")]
			[DataRow((UInt32) 24, "  a  ", "a")]
			[DataRow((UInt32) 25, "   a  ", "a")]
			[DataRow((UInt32) 26, "   a   ", "a")]
			[DataRow((UInt32) 27, " ø", "ø")]
			[DataRow((UInt32) 28, "  ø", "ø")]
			[DataRow((UInt32) 29, "   ø", "ø")]
			[DataRow((UInt32) 30, "ø ", "ø")]
			[DataRow((UInt32) 31, "ø  ", "ø")]
			[DataRow((UInt32) 32, "ø   ", "ø")]
			[DataRow((UInt32) 33, " ø ", "ø")]
			[DataRow((UInt32) 34, "  ø ", "ø")]
			[DataRow((UInt32) 35, "  ø  ", "ø")]
			[DataRow((UInt32) 36, "   ø  ", "ø")]
			[DataRow((UInt32) 37, "   ø   ", "ø")]
			[DataRow((UInt32) 38, " Jan Novák", "JanNovák")]
			[DataRow((UInt32) 39, "  Jan Novák", "JanNovák")]
			[DataRow((UInt32) 40, "   Jan Novák", "JanNovák")]
			[DataRow((UInt32) 41, "Jan Novák ", "JanNovák")]
			[DataRow((UInt32) 42, "Jan Novák  ", "JanNovák")]
			[DataRow((UInt32) 43, "Jan Novák   ", "JanNovák")]
			[DataRow((UInt32) 44, " Jan Novák ", "JanNovák")]
			[DataRow((UInt32) 45, "  Jan Novák ", "JanNovák")]
			[DataRow((UInt32) 46, "  Jan Novák  ", "JanNovák")]
			[DataRow((UInt32) 47, "   Jan Novák  ", "JanNovák")]
			[DataRow((UInt32) 48, "   Jan Novák   ", "JanNovák")]
			[DataRow((UInt32) 49, " Jan  Novák", "JanNovák")]
			[DataRow((UInt32) 50, "  Jan  Novák", "JanNovák")]
			[DataRow((UInt32) 51, "   Jan  Novák", "JanNovák")]
			[DataRow((UInt32) 52, "Jan  Novák ", "JanNovák")]
			[DataRow((UInt32) 53, "Jan  Novák  ", "JanNovák")]
			[DataRow((UInt32) 54, "Jan  Novák   ", "JanNovák")]
			[DataRow((UInt32) 55, " Jan  Novák ", "JanNovák")]
			[DataRow((UInt32) 56, "  Jan  Novák ", "JanNovák")]
			[DataRow((UInt32) 57, "  Jan  Novák  ", "JanNovák")]
			[DataRow((UInt32) 58, "   Jan  Novák  ", "JanNovák")]
			[DataRow((UInt32) 59, "   Jan  Novák   ", "JanNovák")]
			public void VariousStringsTest(UInt32 testNumber, string entryText, string expected) => Assert.AreEqual(expected, entryText.RemoveAllWhitespaces());

			// Note: https://medium.com/@pjbgf/asserting-equality-in-your-c-unit-tests-837b423024bf
			// Note 2: https://docs.microsoft.com/cs-cz/dotnet/csharp/how-to/compare-strings
		}
	}
}
