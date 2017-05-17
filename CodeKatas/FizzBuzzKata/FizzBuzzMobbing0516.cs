using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzMobbing0516
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1AsString()
        {
            //arrange
            FizzBuzz fizz = new FizzBuzz();
            //act
            int input = 1;
            //assert
            fizz.Evaluate(input).Should().Be(input.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void FizzForMultipleOf3()
        {
            //arrange
            FizzBuzz fiz = new FizzBuzz();
            //act
            int input = 3;
            //assert
            fiz.Evaluate(input).Should().Be("fizz");
        }


        [TestMethod, TestCategory("Unit")]
        public void BuzzForMultiplesOf5()
        {
            //arrange
            FizzBuzz buzz = new FizzBuzz();
            //act
            int input = 5;
            //assert
            buzz.Evaluate(input).Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void FizzBuzzForMultiplesOf3And5()
        {
            //arrange
            FizzBuzz buzz = new FizzBuzz();
            //act
            int input = 30;
            //assert
            buzz.Evaluate(input).Should().Be("fizzbuzz");
        }
        public class FizzBuzz
        {
            public string Evaluate(int input)
            {
                if (IsMod15(input)) return "fizzbuzz";
                if (IsMod3(input)) return "fizz";
                if (IsMod5(input)) return "buzz";
                return input.ToString();
            }
            private bool IsMod15(int input) => IsMod3(input) && IsMod5(input);
            private bool IsMod5(int input) => input % 5 == 0;
            private bool IsMod3(int input) => input % 3 == 0;
        }
    }
}
