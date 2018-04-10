using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class Katapractice20180322B
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringForInt()
        {
            //arrange
            //act
            string result = ConvertToFizzBuzz(1);

            //assert
            result.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOfThree()
        {
            //arrange
            //act
            string result = ConvertToFizzBuzz(3);

            //assert
            result.Should().Be("Fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOfFive()
        {
            //arrange
            //act
            string result = ConvertToFizzBuzz(5);

            //assert
            result.Should().Be("Buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultiplesOfThreeAndFive()
        {
            //arrange
            //act
            string result = ConvertToFizzBuzz(15);

            //assert
            result.Should().Be("FizzBuzz");
        }


        private string ConvertToFizzBuzz(int numberToConvert)
        {
            if (numberToConvert % 15 == 0 ) return "FizzBuzz";
            if (numberToConvert % 5 == 0) return "Buzz";
            if (numberToConvert % 3 == 0) return "Fizz";
            return numberToConvert.ToString();
        }
    }
}
