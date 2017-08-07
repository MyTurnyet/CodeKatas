using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzOoKata20170807
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnString1ForNumber1()
        {
            //arrange
            IFizzBuzz fizzBuzz = new FizzBuzz();
            IFizzBuzzNumber inputNumber = new FizzBuzzNumber(1);
            IFizzBuzzNumber expectedNumber = new FizzBuzzNumber(1);
            IFizzBuzzResult expectedResult = new NumberResult(expectedNumber);
            //act
            IFizzBuzzResult actualResultNumber = fizzBuzz.Calculate(inputNumber);

            //assert
            actualResultNumber.Equals(expectedResult).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOfThree()
        {
            //arrange
            IFizzBuzz fizzBuzz = new FizzBuzz();
            IFizzBuzzNumber inputNumber = new FizzBuzzNumber(3);
            IFizzBuzzResult expectedResult = new FizzResult();
            //act
            IFizzBuzzResult actualResult = fizzBuzz.Calculate(inputNumber);

            //assert
            actualResult.Equals(expectedResult).Should().BeTrue();
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFizzForMultipleOfFive()
        {
            //arrange
            IFizzBuzz fizzBuzz = new FizzBuzz();
            IFizzBuzzNumber inputNumber = new FizzBuzzNumber(5);
            IFizzBuzzResult expectedResult = new BuzzResult();
            //act
            IFizzBuzzResult actualResult = fizzBuzz.Calculate(inputNumber);

            //assert
         //   actualResult.Equals(expectedResult).Should().BeTrue();
        }

    }


    public interface IModOperator { }
    public interface IFizzBuzzResult { }

    public interface IFizzBuzzNumber
    {
        string AsString();
        int AsInt();
    }
    public interface IFizzBuzz
    {
        IFizzBuzzResult Calculate(IFizzBuzzNumber inputNumber);
    }

    public class FizzResult : FizzBuzzResult
    {
        public FizzResult() : base("fizz"){}
    }
    public class BuzzResult : FizzBuzzResult
    {
        public BuzzResult() : base("buzz"){}

     
    }
    public class NumberResult : FizzBuzzResult
    {
        public NumberResult(IFizzBuzzNumber inputNumber) : base(inputNumber.AsString()) { }
    }

    public abstract class FizzBuzzResult : IFizzBuzzResult
    {
        private readonly string _origin;

        protected FizzBuzzResult(string origin)
        {
            _origin = origin;
        }
        private bool Equals(FizzBuzzResult other) => other._origin.Equals(this._origin);
        public override bool Equals(object obj) => obj is FizzBuzzResult && Equals((FizzBuzzResult)obj);

        public virtual void Collect(StringBuilder sb)
        {
            sb.Append(_origin);
        }
    }


    public class FizzBuzzNumber : IFizzBuzzNumber
    {
        private readonly int _origin;

        public FizzBuzzNumber(int origin)
        {
            _origin = origin;
        }
        private bool Equals(FizzBuzzNumber other) => other._origin.Equals(this._origin);
        public override bool Equals(object obj) => obj is FizzBuzzNumber && Equals((FizzBuzzNumber)obj);
        public string AsString() => _origin.ToString();
        public int AsInt()
        {
            return _origin;
        }
    }

    public class ModOperator : IModOperator
    {
        private readonly IFizzBuzzNumber _inputNumber;
        private readonly int _mod;

        public ModOperator(IFizzBuzzNumber inputNumber, int mod)
        {
            _inputNumber = inputNumber;
            _mod = mod;
        }
        public bool Exact() => _inputNumber.AsInt() % _mod == 0;
    }
    public class FizzBuzz : IFizzBuzz
    {
        public IFizzBuzzResult Calculate(IFizzBuzzNumber inputNumber)
        {
            StringBuilder sb = new StringBuilder();
            if (new ModOperator(inputNumber, 5).Exact())
            {
                new BuzzResult().Collect(sb);
                
            }
            if(new ModOperator(inputNumber, 3).Exact()) return new FizzResult();
            return new NumberResult(inputNumber);
        }
    }


    
}
