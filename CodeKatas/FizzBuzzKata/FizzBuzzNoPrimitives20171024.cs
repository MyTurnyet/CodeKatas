using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzNoPrimitives20171024
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldBeEqual()
        {
            //arrange
            IReturnValue returnValue = new NumberAsString(1);
            IReturnValue returnValue2 = new NumberAsString(1);
            returnValue2.Should().Be(returnValue);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotBeEqual()
        {
            //arrange
            IReturnValue returnValue = new NumberAsString(1);
            IReturnValue returnValue2 = new NumberAsString(2);
            returnValue2.Should().NotBe(returnValue);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1ForGiven1()
        {
            //arrange
            IReturnValue expectedReturnValue = new NumberAsString(1);
            //act
            FizzBuzzNoPrimitives fizzBuzzNoPrimitives = new FizzBuzzNoPrimitives(1);
            //assert

            fizzBuzzNoPrimitives.Output().Should().Be(expectedReturnValue);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzFor3()
        {
            //arrange
            IReturnValue expectedReturnValue = new FizzValue();
            //act
            FizzBuzzNoPrimitives fizzBuzzNoPrimitives = new FizzBuzzNoPrimitives(3);
            //assert
            fizzBuzzNoPrimitives.Output().Should().Be(expectedReturnValue);

        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzFor5()
        {
            //arrange
            IReturnValue expectedReturnValue = new BuzzValue();
            //act
            FizzBuzzNoPrimitives fizzBuzzNoPrimitives = new FizzBuzzNoPrimitives(5);
            //assert
            fizzBuzzNoPrimitives.Output().Should().Be(expectedReturnValue);

        }
        public interface IReturnValue
        {
            bool Equals(object obj);
        }

        private abstract class ReturnValue : IReturnValue
        {
            private readonly string _text;

            public ReturnValue(string text)
            {
                _text = text;
            }

            public override bool Equals(object obj)
            {
                return (ReturnValue)obj != null && _text == ((ReturnValue)obj)._text;
            }
        }

        private class FizzValue : ReturnValue
        {
            public FizzValue() : base("Fizz")
            {
            }
        }

        private class BuzzValue : ReturnValue
        {
            public BuzzValue() : base("Buzz")
            { }
        }

        private class NumberAsString : ReturnValue
        {
            public NumberAsString(int inputValue) : base(inputValue.ToString()){}
        }

        private class FizzBuzzNoPrimitives
        {
            private readonly int _inputValue;

            public FizzBuzzNoPrimitives(int inputValue)
            {
                _inputValue = inputValue;
            }

            public ReturnValue Output()
            {
                if (_inputValue % 3 == 0)  return new FizzValue();
                if (_inputValue == 5) return new BuzzValue();
                return new NumberAsString(_inputValue);
            }
        }
    }

    
}
