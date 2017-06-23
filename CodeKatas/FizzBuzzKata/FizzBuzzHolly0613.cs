using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzHolly0613
    {
        [TestCategory("Unit")]
        [DataTestMethod]
        [DataRow(1, "1", "Error with string of number")]
        [DataRow(2, "2", "Error with string of number")]
        [DataRow(3, "fizz", "Error with mod 3 string")]
        [DataRow(6, "fizz", "Error with mod 3 string")]
        [DataRow(5, "buzz", "Error with mod 5 string")]
        [DataRow(10, "buzz", "Error with mod 5 string")]
        [DataRow(15, "fizzbuzz", "Error with mod 15 string")]
        [DataRow(30, "fizzbuzz", "Error with mod 15 string")]
        public void ShouldReturnInputAsExpected(int input, string expected, string errorMessage)
        {
            CalculateFizzBuzz(input).Should().Be(expected, errorMessage);
        }

        private string CalculateFizzBuzz(int inputNumber)
        {
            if (inputNumber % 15 == 0) { return "fizzbuzz"; }

            //if (inputNumber % 5 == 0 && inputNumber % 3 == 0) { return "fizzbuzz"; }

            if (inputNumber % 5 == 0) { return "buzz"; }
            if (inputNumber % 3 == 0) { return "fizz"; }
            return inputNumber.ToString();
        }
    }
}
