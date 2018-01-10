using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGame20180105
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldEquateScores()
        {
            //arrange
            Score score1 = new Score(9);
            Score score2 = new Score(9);

            //assert
            score2.Should().Be(score1);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            Score score = new Score(0);
            //act
            BowlingGame bowlingGame = new BowlingGame();
            Score actualScore = bowlingGame.Score();
            //assert
            actualScore.Should().Be(score);

        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGameOfOnePinEachBall()
        {
            //arrange
            Score score = new Score(20);
            BowlingGame bowlingGame = new BowlingGame();
            for (int ballsRolledCount = 0; ballsRolledCount < 20; ballsRolledCount++)
            {
                bowlingGame.BallRolled(1);
            }
            
            //act

            Score actualScore = bowlingGame.Score();
            //assert
            actualScore.Should().Be(score);

        }

        private class Score
        {
            private readonly int _pinsHit;

            public Score(int pinsHit)
            {
                _pinsHit = pinsHit;
            }

            public override bool Equals(object obj) => Equals((Score)obj);
            private bool Equals(Score other) => this.GetHashCode() == other.GetHashCode();
            public override int GetHashCode() => _pinsHit;
            public static Score operator +(Score first, Score second) => new Score(first._pinsHit + second._pinsHit);
        }

        private class BowlingGame
        {
            private Score _totalScore = new Score(0);

            public Score Score()
            {
                return new Score(0) + _totalScore;
            }
            public void BallRolled(int pinsHit) => _totalScore += new Score(pinsHit);
        }
    }
}
