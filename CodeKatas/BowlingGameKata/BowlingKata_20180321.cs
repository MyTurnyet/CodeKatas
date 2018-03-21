using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingKata20180321
    {
        [TestMethod]
        public void ShouldScoreGutterGame()
        {
            List<int> pinsHit = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            IBowlingGame bowlingGame = new BowlingGame(pinsHit);
            int totalScore = bowlingGame.TotalScore();

            totalScore.Should().Be(0);
        }

        [TestMethod]
        public void ShouldScoreGameOfAllOnes()
        {
            List<int> pinsHit = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            IBowlingGame bowlingGame = new BowlingGame(pinsHit);
            int totalScore = bowlingGame.TotalScore();

            totalScore.Should().Be(20);
        }

        private class BowlingGame : IBowlingGame
        {
            private readonly List<int> _pinsHit;

            public BowlingGame(List<int> pinsHit)
            {
                _pinsHit = pinsHit;
            }


            public int TotalScore()
            {
                return _pinsHit.Sum();
            }
        }

        private interface IBowlingGame
        {
            int TotalScore();
        }
    }


}
