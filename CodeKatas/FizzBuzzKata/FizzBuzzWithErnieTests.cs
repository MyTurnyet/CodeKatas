using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzWithErnieTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCorrectObjectWithObjInput()
        {
            //arrange
            FizzBuzzInput input = new FizzBuzzInput(1);
            IFizzBuzzReturnValue expected = new FizzBuzzReturnValue(input);
            //act
            IFizzBuzzReturnValue actual = FizzBuzzErnieObj(input);
            //assert
            actual.Should().Be(expected);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCorrectObject()
        {
            //arrange
            IFizzBuzzReturnValue expected = new FizzBuzzReturnValue("1");
            //act
            IFizzBuzzReturnValue actual = FizzBuzzErnieObj(1);
            //assert
            actual.Should().Be(expected);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCorrectObjectFor2()
        {
            //arrange
            IFizzBuzzReturnValue expected = new FizzBuzzReturnValue("2");
            //act
            IFizzBuzzReturnValue actual = FizzBuzzErnieObj(2);
            //assert
            actual.Should().Be(expected);
        }

        private FizzBuzzReturnValue FizzBuzzErnieObj(int i)
        {
            return new FizzBuzzReturnValue(i.ToString());
        }

        private FizzBuzzReturnValue FizzBuzzErnieObj(FizzBuzzInput input)
        {
            return new FizzBuzzReturnValue(new FizzBuzzInput(1));
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1AsString()
        {
            
            //act
            string actual = FizzBuzzErnie(1);
            //assert

            actual.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzFor3()
        {
            //act
            string actual = FizzBuzzErnie(3);
            //assert
            actual.Should().Be("Fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnBuzzFor5()
        {
            //act
            string actual = FizzBuzzErnie(5);
            //assert
            actual.Should().Be("Buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor15()
        {
            //act
            string actual = FizzBuzzErnie(15);
            //assert
            actual.Should().Be("FizzBuzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzBuzzFor30()
        {
            //act
            string actual = FizzBuzzErnie(30);

            //assert
            actual.Should().Be("FizzBuzz");
        }

        private string FizzBuzzErnie(int valueToCheck)
        {
            if (valueToCheck % 15 == 0) return "FizzBuzz";
            if (valueToCheck % 3 == 0) return "Fizz";
            if (valueToCheck % 5 == 0) return "Buzz";

            return valueToCheck.ToString();
        }
        private class FizzBuzzReturnValue : IFizzBuzzReturnValue
        {
            private readonly FizzBuzzInput _inputObj;
            private readonly string _valueToCheck;

            public FizzBuzzReturnValue(string valueToCheck)
            {
                _valueToCheck = valueToCheck;
            }

            public FizzBuzzReturnValue(FizzBuzzInput inputObj)
            {
                _inputObj = inputObj;
            }

            public override bool Equals(object obj)
            {
                return (obj as FizzBuzzReturnValue) != null && (obj as FizzBuzzReturnValue)._valueToCheck == _valueToCheck;
            }

            public override int GetHashCode()
            {
                return _valueToCheck.GetHashCode();
            }
        }
        private interface IFizzBuzzReturnValue
        {
            bool Equals(object obj);
            int GetHashCode();
        }

        private class FizzBuzzInput
        {
            private int v;

            public FizzBuzzInput(int v)
            {
                this.v = v;
            }
        }
    }
}
