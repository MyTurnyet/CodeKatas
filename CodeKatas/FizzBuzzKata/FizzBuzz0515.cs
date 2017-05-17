using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzz0515
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1WhenPassed1()
        {
            //act
            string actualValue = CalculateFizzBuzz(1);
            //assert
            actualValue.Should().Be(1.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldFizzWhenPassedMultipleOf3()
        {
            //act
            string actualValue = CalculateFizzBuzz(9);
            //assert
            actualValue.Should().Be("fizz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldBuzzWhenPassedMultipleOf5()
        {
            //act
            string actualValue = CalculateFizzBuzz(25);
            //assert
            actualValue.Should().Be("buzz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldFizzBuzzWhenPassed15()
        {
            //act
            string actualValue = CalculateFizzBuzz(15);
            //assert
            actualValue.Should().Be("fizzbuzz");
        }

        private string CalculateFizzBuzz(int inputValue)=>Mod3Text(inputValue) + Mod5Text(inputValue) + NonFizzBuzzNumberText(inputValue);
        private string NonFizzBuzzNumberText(int inputValue)=>(!IsMod5(inputValue) && !IsMod3(inputValue)) ? inputValue.ToString() : string.Empty;
        private string Mod5Text(int inputValue)=>IsMod5(inputValue) ? "buzz" : string.Empty;
        private string Mod3Text(int inputValue)=>IsMod3(inputValue)?"fizz":string.Empty;
        private bool IsMod5(int inputValue)=>inputValue % 5 == 0;
        private bool IsMod3(int inputValue)=>inputValue % 3 == 0;
    }
}
