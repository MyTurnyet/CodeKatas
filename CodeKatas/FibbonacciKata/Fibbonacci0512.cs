using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FibbonacciKata
{
    [TestClass]
    public class Fibbonacci0512
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn0ForInput0()
        {
            //arrange
            int expectedValue = 0;
            //act
            int actualValue = CalculateFibbonacci(expectedValue);
            //assert
            actualValue.Should().Be(expectedValue);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1ForInput1()
        {
            //arrange
            int expectedValue = 1;
            //act
            int actualValue = CalculateFibbonacci(expectedValue);
            //assert
            actualValue.Should().Be(expectedValue);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn3ForInput2()
        {
            //arrange
            int expectedValue = 1;
            int inputValue = 2;
            //act
            int actualValue = CalculateFibbonacci(inputValue);
            //assert
            actualValue.Should().Be(expectedValue);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn3ForInput5()
        {
            //arrange
            int expectedValue = 13;
            int inputValue = 7;
            //act
            int actualValue = CalculateFibbonacci(inputValue);
            //assert
            actualValue.Should().Be(expectedValue);
        }
        private int CalculateFibbonacci(int inputValue)
        {
            if (inputValue < 0) return 0;
            if (inputValue == 0 || inputValue == 1) return inputValue;
            return CalculateFibbonacci(inputValue - 1) + CalculateFibbonacci(inputValue - 2);
        }
    }
}
