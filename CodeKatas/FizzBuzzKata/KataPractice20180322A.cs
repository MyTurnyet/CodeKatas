using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    /// <summary>
    /// Summary description for KataPractice20180322A
    /// </summary>
    [TestClass]
    public class KataPractice20180322A
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnStringResponseForInput()
        {
            //arrange
            KataInput kataInput = new KataInput(1);
            ConvertFizzBuzz convertFizzBuzz = new ConvertFizzBuzz(kataInput);
            //act
            StringResponse response = convertFizzBuzz.Result();
            //assert
            response.Should().Be(new StringResponse("1"));
        }
        
        private class ConvertFizzBuzz
        {
            private readonly KataInput _kataInput;

            public ConvertFizzBuzz(KataInput kataInput)
            {
                _kataInput = kataInput;
            }

            public StringResponse Result()
            {
                return new StringResponse("1");
            }
        }

        private class KataInput
        {
            private readonly int _inputValue;

            public KataInput(int inputValue)
            {
                _inputValue = inputValue;
            }
        }

        private class StringResponse
        {
            private readonly string _value;

            public StringResponse(string value)
            {
                _value = value;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as StringResponse);
            }

            private bool Equals(StringResponse other)
            {
                return string.Equals(_value, other._value);
            }

            public override int GetHashCode()
            {
                return (_value != null ? _value.GetHashCode() : 0);
            }
        }
    }
}
