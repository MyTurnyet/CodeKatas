using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingKata20170929
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnGutterGame()
        {
            //arrange
            int[] pinsHit = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            //act
            int score = BowlingScore(pinsHit);
            //assert
            score.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldtestName()
        {
            //arrange
            
            //act

            //assert
        }

        private int BowlingScore(int[] pinsHit)
        {
            return 0;
        }
    }
}
