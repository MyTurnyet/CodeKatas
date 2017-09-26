using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzTest20170926
    {

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTwoAsAString() => DoFizzBuzz(2).Should().Be("2");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3() => DoFizzBuzz(9).Should().Be("Fizz");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOf5() => DoFizzBuzz(10).Should().Be("Buzz");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultipleOf15() => DoFizzBuzz(15).Should().Be("FizzBuzz");

        private string DoFizzBuzz(int inputValue) => Fizz(inputValue) + Buzz(inputValue) + NonFizzBuzz(inputValue);
        private string NonFizzBuzz(int inputValue) => inputValue % 3 == 0 || inputValue % 5 == 0 ? string.Empty : inputValue.ToString();
        private string Fizz(int inputValue) => (inputValue % 3 == 0) ? "Fizz" : "";
        private string Buzz(int inputValue) => (inputValue % 5 == 0) ? "Buzz" : "";
    }
}
