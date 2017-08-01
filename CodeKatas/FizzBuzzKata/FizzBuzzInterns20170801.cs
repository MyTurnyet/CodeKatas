using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzInterns20170801
    {
        //given number 1-n
        //return number as string 1 ="1", 997="997"
        //If divisible by 3, return "fizz"
        //If divisible by 5, return "buzz"
        //If divisible by 3 and divisible by 5, return "fizzbuzz"

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString()
        {
            //act
            string actual = CalculateFizzBuzz(1);

            //assert
            actual.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOfThree()
        {
            //act
            string actual = CalculateFizzBuzz(3);
            //assert
            actual.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOfFive()
        {
            //act
            string actual = CalculateFizzBuzz(5);
            //assert
            actual.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultipleOfThreeAndFive()
        {
            //act
            string actual = CalculateFizzBuzz(15);
            //assert
            actual.Should().Be("fizzbuzz");
        }
        
        private string CalculateFizzBuzz(int input)
        {
            if (input % 15 == 0) return "fizzbuzz";
            if (input % 5 == 0) return "buzz";
            if (input % 3 == 0) return "fizz";
            return input.ToString();
        }
    }
}
