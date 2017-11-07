using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzNoPrimitives20171107
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTheNumber1AsString()
        {
            //arrange
            FizzBuzz1107 subject = new FizzBuzz1107(1);
            TextObj expectedTextObj = new TextObj("1");

            // act
            TextObj result = subject.Result();

            //assert
            result.Should().Be(expectedTextObj);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForANumberDivisibleBy3()
        {
            //arrange
            FizzBuzz1107 fizzBuzz = new FizzBuzz1107(3);
            TextObj expectedFizzObj = new TextObj("Fizz");

            //act
            TextObj result = fizzBuzz.Result();

            //assert
            result.Should().Be(expectedFizzObj);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzForNumberDivisibleBy5()
        {
            //arrange
            FizzBuzz1107 fizzBuzz = new FizzBuzz1107(5);

            //act
            TextObj result = fizzBuzz.Result();

            //assert
            result.Should().Be(new TextObj("Buzz"));
        }

        //[TestMethod, TestCategory("Unit")]
        //public void ShouldReturnFizzBuzzForNumberDivisiblyBy3And5()
        //{
        //    //arrange
        //    FizzBuzz1107 fizzBuzz = new FizzBuzz1107(15);

        //    //act
        //    string result = fizzBuzz.Result();

        //    //assert
        //    result.Should().Be("fizzbuzz");
        //}

        private class TextObj
        {
            private readonly string _text;

            public TextObj(string text) => _text = text;

            public override bool Equals(object obj)
            {
                TextObj textObj = (TextObj) obj;
                return textObj != null && _text == textObj._text;
            }
        }

        private class FizzBuzz1107
        {
            private readonly int _numberToCalculate;

            public FizzBuzz1107(int numberToCalculate) => _numberToCalculate = numberToCalculate;

            public TextObj Result()
            {
                //if (IsFizzBuzzy()) return "fizzbuzz";
                if (IsFizzy()) return new TextObj("Fizz");
                if (IsBuzzy()) return new TextObj("Buzz");
                return new TextObj(_numberToCalculate.ToString());
            }

            private bool IsFizzBuzzy() => IsFizzy() && IsBuzzy();
            private bool IsBuzzy() => _numberToCalculate % 5 == 0;
            private bool IsFizzy() => _numberToCalculate % 3 == 0;
        }
    }

}
