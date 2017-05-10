using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzz0510a
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString()
        {
            //act
            string actualOutput = FizzbuzzCompare(1);
            //assert
            actualOutput.Should().Be(1.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOf3()
        {
            //act
            string actualOutput = FizzbuzzCompare(6);
            //assert
            actualOutput.Should().Be("fizz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOf5()
        {
            //act
            string actualOutput = FizzbuzzCompare(10);
            //assert
            actualOutput.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultipleOf15()
        {
            //act
            string acutalOutput = FizzbuzzCompare(45);
            //assert
            acutalOutput.Should().Be("fizzbuzz");
        }

        private string FizzbuzzCompare(int inputNumber)=>ReturnMod3String(inputNumber)+ ReturnMod5String(inputNumber)+ ReturnNonFizzBuzzString(inputNumber);
        private string ReturnNonFizzBuzzString(int inputNumber)=>(!IsMod3(inputNumber) && !IsMod5(inputNumber)) ? inputNumber.ToString() : String.Empty;
        private string ReturnMod3String(int inputNumber)=>!IsMod3(inputNumber) ? string.Empty : "fizz";
        private string ReturnMod5String(int inputNumber) => !IsMod5(inputNumber) ? string.Empty : "buzz";
        private bool IsMod5(int inputNumber) => inputNumber % 5 == 0;
        private bool IsMod3(int inputNumber) => inputNumber % 3 == 0;
    }
}
