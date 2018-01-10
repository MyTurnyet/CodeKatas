using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class UnitTestsForFizzBuzzKata20180109
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringOfInt1()
        {
            //arrange
            //act
            string one = ReturnStringOfGivenInt(1); 
            //assert
            one.Should().Be("1");

        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringOfInt2()
        {
            //arrange
            //act
            string two = ReturnStringOfGivenInt(2); 
            
            //assert
            two.Should().Be("2");
        }

        private string ReturnStringOfGivenInt(int valueToTest)
        {
            return valueToTest.ToString();
        }
    }
}
