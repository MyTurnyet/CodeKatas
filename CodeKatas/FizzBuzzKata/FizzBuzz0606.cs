using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzz0606
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString()
        {
            //act
            string result = CalculateFizzBuzz(1);
            //assert
            result.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultipleOfThreeAsFizz()
        {
            //act
            string result = CalculateFizzBuzz(9);
            //assert
            result.Should().Be("fizz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultipleOfFiveAsBuzz()
        {
            //act
            string result = CalculateFizzBuzz(35);
            //assert
            result.Should().Be("buzz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFifteenAsFizzBuzz()
        {
            //act
            string result = CalculateFizzBuzz(15);
            //assert
            result.Should().Be("fizzbuzz");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnThirtyAsFizzBuzz()
        {
            //act
            string result = CalculateFizzBuzz(30);
            //assert
            result.Should().Be("fizzbuzz");
        }
        private string CalculateFizzBuzz(int inputNumber) => Mod3String(inputNumber)+Mod5String(inputNumber)+NonFizzBuzzString(inputNumber);
        private string NonFizzBuzzString(int inputNumber) => (!IsMod3(inputNumber) && !IsMod5(inputNumber)) ? inputNumber.ToString() : string.Empty;
        private string Mod5String(int inputNumber) => (IsMod5(inputNumber)) ? "buzz" : string.Empty;
        private string Mod3String(int inputNumber) => (IsMod3(inputNumber))?"fizz":string.Empty;
        private bool IsMod5(int inputNumber) => inputNumber % 5 == 0;
        private bool IsMod3(int inputNumber) => inputNumber % 3 == 0;
    }
}
