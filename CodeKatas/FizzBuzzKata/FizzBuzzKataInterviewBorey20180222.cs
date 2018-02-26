using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzKataInterviewBorey20180222
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringOfNumber()
        {
            //arrange
            var fizzbuzz = new FizzBuzz();

            //act
            var result = fizzbuzz.CreateFizzBuzz(1);

            //assert
            result.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzGivenMultipleOfThree()
        {
            //arrange
            var fizzbuzz = new FizzBuzz();

            //act
            var result = fizzbuzz.CreateFizzBuzz(3);

            //assert
            result.Should().Be("Fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzGivenMultipleOfFive()
        {
            //arrange
            var fizzbuzz = new FizzBuzz();
            //act
            var result = fizzbuzz.CreateFizzBuzz(5);
            //assert
            result.Should().Be("Buzz");
        }

        public class FizzBuzz
        {
            public string CreateFizzBuzz(int number)
            {
                if (number % 3 == 0)
                {
                    return "Fizz";
                }
                if (number % 5  == 0)
                {
                    return "Buzz";
                }
                return number.ToString();
            }
        }
    }
}
