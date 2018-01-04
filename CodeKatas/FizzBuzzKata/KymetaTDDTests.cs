using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class KymetaTddTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringForInt()
        {
            //arrange
            string actual = KymetaFizzBuzz(1);

            //assert
            actual.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzFor3()
        {
            //arrange
            string actual = KymetaFizzBuzz(3);

            //assert
            actual.Should().Be("fizz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzFor9()
        {
            //arrange
            string actual = KymetaFizzBuzz(9);

            //assert
            actual.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForDivisibleBy5()
        {
            //arrange
            string actual = KymetaFizzBuzz(455);
            //act\
            actual.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor15()
        {
            //arrange
            string actual = KymetaFizzBuzz(15);
            //act

            //assert
            actual.Should().Be("fizzbuzz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor45()
        {
            //arrange
            string actual = KymetaFizzBuzz(45);
            //act

            //assert
            actual.Should().Be("fizzbuzz");
        }
        private string KymetaFizzBuzz(int valueToCheck)
        {
            string output = string.Empty;
            if (valueToCheck % 3 == 0) output += "fizz";
            if (valueToCheck % 5 == 0) output += "buzz";
            
            return string.IsNullOrEmpty(output)? valueToCheck.ToString():output;
        }
    }
}
