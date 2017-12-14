using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzz20171017
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString() => FizzBuzz(1).Should().Be(1.ToString());

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultiplesOfThree() => FizzBuzz(27).Should().Be("Fizz");

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultiplesOfFive() => FizzBuzz(10).Should().Be("Buzz");

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultiplesOfFiveAndThree() => FizzBuzz(15).Should().Be("FizzBuzz");

        private string FizzBuzz(int valueToCheck)
        {
            string notfizzbuzz =  CalculateNotFizzBuzz(valueToCheck);
            string buzz = CalculateBuzz(valueToCheck);
            string fizz = CalculateFizz(valueToCheck);
            return fizz + buzz + notfizzbuzz;
        }

        private string CalculateNotFizzBuzz(int valueToCheck) => IsMod5(valueToCheck) || IsMod3(valueToCheck) ? string.Empty: valueToCheck.ToString() ;
        private string CalculateFizz(int valueToCheck) => IsMod3(valueToCheck) ? "Fizz" : string.Empty;
        private string CalculateBuzz(int valueToCheck) => IsMod5(valueToCheck) ? "Buzz" : string.Empty;
        private bool IsMod5(int valueToCheck) => valueToCheck % 5 == 0;
        private bool IsMod3(int valueToCheck) => valueToCheck % 3 == 0;
    }
}
