using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class CodeKataFluentLanguage20180214
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberAsAString()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(1).Returns().NumberAsAString();

            //assert
            actualReturnValue.Should().Be("1");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldNotReturnNumber3AsAString()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(3).Returns().NumberAsAString();

            //assert
            actualReturnValue.Should().NotBe("3");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldNotReturnNumber5AsAString()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(5).Returns().NumberAsAString();

            //assert
            actualReturnValue.Should().NotBe("5");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberDivisibleBy3AsFizz()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(3).Returns().Fizz();

            //assert
            actualReturnValue.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotReturnNumberNotDivisibleBy3AsFizz()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(4).Returns().Fizz();

            //assert
            actualReturnValue.Should().NotBe("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNumberDivisibleBy5AsBuzz()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(5).Returns().Buzz();

            //assert
            actualReturnValue.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotReturnNumberNotDivisibleByAsBuzz()
        {
            //arrange
            FluentFizzBuzz fluentFizzBuzz = new FluentFizzBuzz();
            //act
            string actualReturnValue = fluentFizzBuzz.WhenPassed(4).Returns().Buzz();

            //assert
            actualReturnValue.Should().NotBe("buzz");
        }

        private class FluentFizzBuzz
        {
            private int _computeValue;

            public FluentFizzBuzz WhenPassed(int valueToCompute)
            {
                _computeValue = valueToCompute;
                return this;
            }

            public FluentFizzBuzz Returns()
            {
                return this;
            }

            public string NumberAsAString()
            {
                if (IsModThree() || IsModFive()) return "";
                return _computeValue.ToString();
            }

            public string Fizz()
            {
                if (!IsModThree()) return "";
                return "fizz";
            }

            public string Buzz()
            {
                if (!IsModFive()) return "";
                return "buzz";
            }

            private bool IsModFive()
            {
                return _computeValue %5==0;
            }

            private bool IsModThree()
            {
                return _computeValue % 3 == 0;
            }
        }
    }
}
