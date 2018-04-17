using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzKata20180417
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringForInt() => ConvertIntToString(1).Should().Be("1");

        private string ConvertIntToString(int toBeConverted)
        {
            return toBeConverted.ToString();
        }
    }
}
