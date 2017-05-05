using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzz0505
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldTakeNumberAndReturnAsString()
        {
            //arrange
            string expectedResult = 2.ToString();
            FizzBuzz fizzbuzz = new FizzBuzz();

            //act
            string actualResult = fizzbuzz.ProcessNumber(2);

            //assert
            actualResult.Should().Be(expectedResult);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3()
        {
            //arrange
            string expectedResult = "fizz";
            FizzBuzz fizzbuzz = new FizzBuzz();

            //act
            string actualResult = fizzbuzz.ProcessNumber(3);

            //assert
            actualResult.Should().Be(expectedResult);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOf5()
        {
            //arrange
            string expectedResult = "buzz";
            FizzBuzz fizzbuzz = new FizzBuzz();

            //act
            string actualResult = fizzbuzz.ProcessNumber(5);

            //assert
            actualResult.Should().Be(expectedResult);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor15()
        {
            //arrange
            string expectedResult = "fizzbuzz";
            FizzBuzz fizzbuzz = new FizzBuzz();

            //act
            string actualResult = fizzbuzz.ProcessNumber(15);

            //assert
            actualResult.Should().Be(expectedResult);
        }

        private class FizzBuzz
        {
            public string ProcessNumber(int inputValue)
            {
                if (IsMod15(inputValue)) return "fizzbuzz";
                if (IsMod3(inputValue)) return "fizz";
                if (IsMod5(inputValue)) return "buzz";
                return inputValue.ToString();
            }
            private static bool IsMod15(int inputValue) => IsMod3(inputValue) && IsMod5(inputValue);
            private static bool IsMod5(int inputValue)=>inputValue %5==0;
            private static bool IsMod3(int inputValue)=>inputValue % 3==0;
        }
    }
}
