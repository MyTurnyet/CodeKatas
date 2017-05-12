using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzbuzzPaired0512
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1AsString()
        {
            //act
            string actualValue = CalculateFizzBuzz(1);

            //assert
            actualValue.Should().Be(1.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3()
        {
            //act
            string actualValue = CalculateFizzBuzz(9);
            //assert
            actualValue.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultiplesOf5()
        {
            //act
            string actualValue = CalculateFizzBuzz(10);
            //assert
            actualValue.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor15()
        {
            //act
            string actualValue = CalculateFizzBuzz(15);
            //assert
            actualValue.Should().Be("fizzbuzz");
        }

        private string CalculateFizzBuzz(int inputValue)=>CalculateFizz(inputValue) + CalculateBuzz(inputValue) + CalculateNonFizzBuzzValue(inputValue);
        private string CalculateNonFizzBuzzValue(int inputValue)=>(!IsMod3(inputValue) && !IsMod5(inputValue)) ? inputValue.ToString() : string.Empty;
        private string CalculateBuzz(int inputValue) => (IsMod5(inputValue)) ? "buzz" : string.Empty;
        private string CalculateFizz(int inputValue) => (IsMod3(inputValue)) ? "fizz" : string.Empty;
        private bool IsMod5(int inputValue) => inputValue % 5 == 0;
        private bool IsMod3(int inputValue) => inputValue % 3 == 0;
    }
}
