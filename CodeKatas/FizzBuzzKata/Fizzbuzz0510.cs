using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class Fizzbuzz0510
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString()
        {
            //act
            string actualValue = CalculateFizzBuzz(1);
            //assert
            actualValue.Should().Be(1.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultiple3AsFizz()
        {
            //act
            string actualValue = CalculateFizzBuzz(6);

            //assert
            actualValue.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultipleOf5AsBuzz()
        {
            //act
            string actualResult = CalculateFizzBuzz(10);
            //assert
            actualResult.Should().Be("buzz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultipleOf15AsFizzBuzz()
        {
            //act
            string actualResult = CalculateFizzBuzz(30);
            //assert
            actualResult.Should().Be("fizzbuzz");
        }


        private string CalculateFizzBuzz(int inputValue)=>GetFizzValue(inputValue) + GetBuzzValue(inputValue) + GetTextOfNonFizzBuzzNumber(inputValue);
        private string GetTextOfNonFizzBuzzNumber(int inputValue)=>(!IsMod3(inputValue) && !IsMod5(inputValue)) ? inputValue.ToString() : string.Empty;
        private string GetBuzzValue(int inputValue)=>!IsMod5(inputValue) ? string.Empty : "buzz";
        private string GetFizzValue(int inputValue)=>!IsMod3(inputValue) ? string.Empty : "fizz";
        private bool IsMod5(int inputValue) => inputValue % 5 == 0;
        private bool IsMod3(int inputValue) => inputValue % 3 == 0;
    }
}
