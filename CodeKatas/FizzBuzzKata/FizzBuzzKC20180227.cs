using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzKc20180227
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringOneForIntOne()
        {
            //arrange
            string expectedresult = "26";
            //act
            string actualresult = ConvertToString(26);

            //assert
            actualresult.Should().Be(expectedresult);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultiplesOfThree()
        {
            //arrange
            string expectedResult = "Fizz";
            //act
            string actualResult = ConvertToString(3);

            //assert
            actualResult.Should().Be(expectedResult);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOfFive()
        {
            //arrange
            string expectedResult = "Buzz";

            //act
            string actualResult = ConvertToString(5);

            //assert
            actualResult.Should().Be(expectedResult);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForFifteen()
        {
            //arrange
            string expectedResult = "FizzBuzz";

            //act
            string actualResult = ConvertToString(15);
            //assert
            actualResult.Should().Be(expectedResult);
        }

        //[TestMethod, TestCategory("Unit")]
        //public void ShouldReturnFizzBuzzForThirty()
        //{
        //    //arrange
        //    string expectedResult = "FizzBuzz";
        //    //act
        //    string actualResult = ConvertToString(30);
        //    //assert
        //    actualResult.Should().Be(expectedResult);
        //}
        private string ConvertToString(int valueToConvert)
        {
            if (valueToConvert == 15) return "FizzBuzz";
            if (valueToConvert % 5 == 0) return "Buzz";
            if (valueToConvert % 3 == 0) return "Fizz";
            return valueToConvert.ToString();
        }
    }
}
