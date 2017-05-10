using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FibonnacciKata
{
    //Takes an number
    //returns sum of previous numbers: 
    //1= 0+1 = 1
    //2 = (0+1) + 2
    //3 = (0+1)+(1+2)+3
    [TestClass]
    public class FibbonacciTests0505
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldTake0AndReturn0()
        {
            //arrange
            Fibbonacci fib = new Fibbonacci();
            //act
            Int64 actualNumber = fib.CalculateFibonnacciNumber(0);

            //assert
            actualNumber.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldTake1AndReturn1()
        {
            //arrange
            Fibbonacci fib = new Fibbonacci();

            //act
            Int64 actualNumber = fib.CalculateFibonnacciNumber(1);

            //assert
            actualNumber.Should().Be(1);
        }


        [TestMethod, TestCategory("Unit")]
        public void ShouldCalculateFor2()
        {
            //arrange
            Fibbonacci fib = new Fibbonacci();
            //act
            Int64 actualNumber = fib.CalculateFibonnacciNumber(2);
            //assert
            actualNumber.Should().Be(3);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldCalculateFor54()
        {
            //arrange
            Fibbonacci fib = new Fibbonacci();
            //act
            Int64 actualNumber = fib.CalculateFibonnacciNumber(54);
            //assert
            actualNumber.Should().Be(1485L);
        }

        private class Fibbonacci
        {
            public uint CalculateFibonnacciNumber(uint currentNumber) =>
                (currentNumber == 1 || currentNumber == 0) ? currentNumber : CalculateFibonnacciNumber(currentNumber - 1) + currentNumber;
        }
    }
}
