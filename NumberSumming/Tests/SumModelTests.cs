using NumberSumming.Models;
using NUnit.Framework;

namespace NumberSumming.Tests
{
    /// <summary>
    /// Class <c>SumModelTests</c> contains unit tests for Class <c>SumModel</c>
    /// </summary>
    [TestFixture]
    public class SumModelTests
    {
        SumModel model;

        [SetUp]
        public void Setup()
        {
            model = new SumModel();
        }

        [Test]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(1500, 500, 500, 500)]
        [TestCase(3, -12, 20, -5)]
        [TestCase(500, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
                  10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
                  10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [TestCase(-100, 500, 400, -1000)]
        [TestCase(9999999998, 999999999999, 999999999999)]
        public void AddingNumbersGeneratesExpectedSum(long expectedSum, params long[] inputs)
        {
            foreach(var num in inputs)
            {
                model.CalculateSum(num);
            }

            Assert.That(model.FormattedSum, Is.EqualTo(expectedSum));
        }

        [Test]
        [TestCase("1", "'1'")]
        [TestCase("-13", "'-13'")]
        [TestCase("0", "-")]
        [TestCase("0", "")]
        public void FormattingNumbersKeepsNumericValues(string expectedNumber, params string[] inputs)
        {
            long result;
            foreach(string num in inputs)
            {
                result = model.FormatNumber(num);
                Assert.That(result.ToString(), Is.EqualTo(expectedNumber));
            }
        }

        [Test]
        [TestCase("1234567890", "12345678901234567890", "1234567890123456789012345678901234567890",
                  "123456789012345678901234567890123456789012345678901234567890")]
        [TestCase("-1313131313", "'-13131313131313131313'")]
        public void FormattingNumbersRemovesExtraDigits(string expectedNumber, params string[] inputs)
        {
            foreach (string num in inputs)
            {
                Assert.That(model.FormatNumber(num).ToString(), Is.EqualTo(expectedNumber));
            }
        }

        [Test]
        [TestCase("Nonnumeric value found, replaced with zero.", "i")]
        [TestCase("Nonnumeric value found, replaced with zero.", "-")]
        [TestCase("Nonnumeric value found, replaced with zero.", "")]
        public void FormattingNumbersCatchesNonnumericValuesGracefully(string expectedErrorMessage, params string[] inputs)
        {
            foreach (string num in inputs)
            {
                long formattedNumber = model.FormatNumber(num);
                Assert.That(model.ErrorMessage, Is.EqualTo(expectedErrorMessage));
                Assert.That(formattedNumber, Is.EqualTo(0));
            }
        }

        [Test]
        [TestCase("1", "'1'")]
        [TestCase("-13", "'-13'")]
        [TestCase("", "'jkgyufvg'")]
        [TestCase("", "'jkgyu!.,%#fjfvg'")]
        [TestCase("-", "'-")]
        [TestCase("", "")]
        public void MakeNumericRemovesNonnumericCharacters(string expected, params string[] inputs)
        {
            foreach (string num in inputs)
            {
                Assert.That(model.MakeNumeric(num), Is.EqualTo(expected));
            }
        }

        [Test]
        [TestCase("Unable to read from file.", "C:\\Users\\Brandon\\Downloads\\notafile.csv")]
        [TestCase("Unable to read from file.", "")]
        public void HandleDataCatchesInvalidFilePathsGracefully(string expectedErrorMessage, params string[] inputs)
        {
            model.HandleData(inputs[0]);
            Assert.That(model.ErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        [TestCase(7283945615, "123456789123", "123456789123", "123456789123", "123456789123", "123456789123")]
        [TestCase(0370367369, "-123456789123", "123456789123", "123456789123", "123456789123", "123456789123")]
        public void FormattingAndAddingValuesGivesCorrectSum(long expectedSum, params string[] inputs)
        {
            foreach (var num in inputs)
            {
                long formattedNumber = model.FormatNumber(num);
                model.CalculateSum(formattedNumber);
            }

            Assert.That(model.FormattedSum, Is.EqualTo(expectedSum));
        }
    }
}
