using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class CodeKata20171003
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnInputAsString() => new FizzBuzz20171003().Evaluate(1).Should().Be("1");

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3() => new FizzBuzz20171003().Evaluate(3).Should().Be("Fizz");

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOf5() => new FizzBuzz20171003().Evaluate(5).Should().Be("Buzz");

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultiplyOf15() => new FizzBuzz20171003().Evaluate(15).Should().Be("FizzBuzz");
    }

    public class FizzBuzz20171003
    {
        public string Evaluate(int input) => Fizz(input) + Buzz(input) + NotFizzBuzz(input);

        private string NotFizzBuzz(int input) => !IsMod3(input) && input % 5 != 0 ? input.ToString() : string.Empty;

        private string Buzz(int input) => input % 5 == 0 ? "Buzz" : string.Empty;

        private string Fizz(int input) => IsMod3(input) ? "Fizz" : string.Empty;

        private static bool IsMod3(int input)
        {
            return input % 3 == 0;
        }
    }
}
