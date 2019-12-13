using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzTests20191213
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_StringOne_WhenPassed_IntegerOne()
        {
            //assign
            var fizzBuzz = new FizzBuzz20191213(1);
            //act
            string one = fizzBuzz.Convert();
            //assert
            one.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_StringTwo_WhenPassed_IntegerTwo()
        {
            //assign
            var fizzBuzz = new FizzBuzz20191213(2);
            //act
            string two = fizzBuzz.Convert();
            //assert
            two.Should().Be("2");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_String_Fizz_WhenPassed_MultipleOf3()
        {
            //assign
            var fizzBuzz = new FizzBuzz20191213(3 * 8);
            //act
            string fizz = fizzBuzz.Convert();
            //assert
            fizz.Should().Be("Fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_String_Fizz_WhenPassed_MultipleOfFive()
        {
            //assign
            var fizzBuzz = new FizzBuzz20191213(5 * 8);
            //act
            string buzz = fizzBuzz.Convert();
            //assert
            buzz.Should().Be("Buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_String_FizzBuzz_WhenPassed_MultipleOf_ThreeAndFive()
        {
            //assign
            var fizzBuzz = new FizzBuzz20191213(4 * 3 * 5);
            //act
            string fizzbuzz = fizzBuzz.Convert();
            //assert
            fizzbuzz.Should().Be("FizzBuzz");
        }
    }

    public class FizzBuzz20191213
    {
        private readonly int _numberToConvert;

        public FizzBuzz20191213(int numberToConvert)
        {
            _numberToConvert = numberToConvert;
        }

        public string Convert()
        {
            if (_numberToConvert % (3 * 5) == 0) return "FizzBuzz";
            if (_numberToConvert % 5 == 0) return "Buzz";
            if (_numberToConvert % 3 == 0) return "Fizz";
            return _numberToConvert.ToString();
        }
    }
}