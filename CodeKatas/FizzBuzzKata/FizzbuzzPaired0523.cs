using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzbuzzPaired0523
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn1AsString() => GetFizzBuzz(1).Should().Be("1");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultiplesOf3AsFizz() => GetFizzBuzz(9).Should().Be("Fizz");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultiplesOf5AsBuzz() => GetFizzBuzz(55).Should().Be("Buzz");
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnMultiplesOf3And5AsFizzBuzz() => GetFizzBuzz(30).Should().Be("FizzBuzz");
        private string GetFizzBuzz(int input) => ReturnMod3Value(input) + ReturnMod5Value(input) + ReturnNotMod3Or5(input);
        private string ReturnNotMod3Or5(int input)=>!IsMod5(input) && !IsMod3(input) ? input.ToString() : string.Empty;
        private string ReturnMod3Value(int input)=>(IsMod3(input)) ? "Fizz" : string.Empty;
        private string ReturnMod5Value(int input)=>(IsMod5(input)) ? "Buzz" : string.Empty;
        private bool IsMod5(int input)=>input % 5 == 0;
        private bool IsMod3(int input)=>input % 3 == 0;
    }
}
