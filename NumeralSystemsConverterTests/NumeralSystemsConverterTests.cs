using NumeralSystemsConverter;

namespace NumeralSystemsConverterTests
{
    public class NumeralSystemsConverterTests
    {
        [TestCase("0110", 2, 4, "12")]
        [TestCase("11220234", 5, 16, "18BC7")]
        [TestCase("58D4f", 17, 9, "772023")]
        [TestCase("201202", 3, 24, "M5")]
        public void CheckCorrectConvertion_ShouldBeCorrect(string value, int numeralSystemFrom, int numeralSystemTo, string expectedResult)
        {
            string actualResult = NumeralSystemConverter.ConvertNumber(value, numeralSystemFrom, numeralSystemTo);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1, 2)]
        [TestCase(2, 0)]
        [TestCase(2, -1)]
        [TestCase(0, 2)]
        public void CheckCorrectConvertion_ShouldBeCorrect(int numeralSystemFrom, int numeralSystemTo)
        {
            try
            {
                NumeralSystemConverter.ConvertNumber("123", numeralSystemFrom, numeralSystemTo);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Numeral system should be more than 1", ex.Message);
                Assert.Pass();
            }

            Assert.Fail("No throw exception");
        }

        [TestCase("021", "2", 2)]
        [TestCase("45C", "C", 12)]
        [TestCase("202345", "5", 5)]
        [TestCase("ab5FP", "P", 24)]
        public void CheckValue_ShouldThrowException(string value, string incorrectSymbol, int numeralSystemFrom)
        {
            try
            {
                NumeralSystemConverter.ConvertNumber(value, numeralSystemFrom, 10);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"{incorrectSymbol} not correspond to {numeralSystemFrom} numeral system", ex.Message);
                Assert.Pass();
            }

            Assert.Fail("No throw exception");
        }

    }
}