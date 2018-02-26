using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzKataGroups20180220
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringForInt() => ConvertToString(17).Should().Be("17");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3() => ConvertToString(333).Should().Be("fizz");
        private string ConvertToString(int valueToConvert) =>
            valueToConvert % 3 == 0 ? "fizz" : valueToConvert.ToString();
    }
}
