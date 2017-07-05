using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzPaired0705Interview
    {
        //int 1-N
        //Should not be 0 or negative
        //if Diagnosis Code is divisible by 3, return "Approved for treatment"
        //if divisible by 5, return "buzz"
        //if divisible by 3 and 5, return "fizzbuzz"
        //else return number as string

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsString()
        {
            //assert
            TranslateNumberToFizzBuzz(1).Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOfThree()
        {
            //assert
            TranslateNumberToFizzBuzz(12).Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForMultipleOfFive()
        {
            //assert
            TranslateNumberToFizzBuzz(5).Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzForMultipleOfThreeAndFive()
        {
            TranslateNumberToFizzBuzz(45).Should().Be("fizzbuzz");
        }

        private string TranslateNumberToFizzBuzz(int numberToTranslate)
        {
            StringBuilder sb = new StringBuilder();
            if (numberToTranslate % 3 == 0) sb.Append("fizz");
            if (numberToTranslate % 5 == 0) sb.Append("buzz");
            return sb.Length == 0 ? numberToTranslate.ToString() : sb.ToString();
        }
    }
}
