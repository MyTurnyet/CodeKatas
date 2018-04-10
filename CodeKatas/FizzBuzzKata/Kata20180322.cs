using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class Kata20180322
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnIntAsString()
        {
            //arrange
            //act
            string strRepresentation = IntegerToString(2);
            //assert
            strRepresentation.Should().Be("2");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForIntDivisibleBy3()
        {
            //arrange
            //act
            string fizz = IntegerToString(3);

            //assert
            fizz.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForInt5()
        {
            //arrange
            //act
            string buzz = IntegerToString(5);
            //assert
            buzz.Should().Be("buzz");
        }

        private string IntegerToString(int numberToConvert)
        {
            if (numberToConvert % 3 == 0) return "fizz";
            if (numberToConvert == 5) return "buzz";
            return numberToConvert.ToString();
        }
    }
}
