using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzzKata
{
    [TestClass]
    class R
    {
        string f = "fizz", g = "buzz";
        [TestMethod]public void A(){B(1).Should().Be("1"); B(6).Should().Be(f); B(10).Should().Be(g); B(15).Should().Be(f + g);}
        string B(int i) => i % 15 == 0 ? f + g : (i % 5 == 0 ? g : (i % 3 == 0 ? f : $"{i}"));
    }
}
