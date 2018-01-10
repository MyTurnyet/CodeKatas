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
        public void ShouldAddScores()
        {
            //arrange
            Score score1 = new Score(3);
            Score score2 = new Score(9);

            //assert
            (score2 + score1).Should().Be(new Score(12));
        }



        [TestMethod, TestCategory("Unit")]
        public void ShouldEquateBalls()
        {
            //arrange
            Ball ball1 = new Ball(new Score(3));
            Ball ball2 = new Ball(new Score(3));

            //assert
            ball2.Should().Be(ball1);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldAddBallsTogether()
        {
            //arrange
            Ball ball1 = new Ball(new Score(3));
            Ball ball2 = new Ball(new Score(5));

            //assert
            (ball1 + ball2).Should().Be(new Score(8));
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            Score score = new Score(0);
            BowlingGame bowlingGame = new BowlingGame();
            AddMultipleBallsToBowlingGame(bowlingGame, 20, 0);
            //act
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
            AddMultipleBallsToBowlingGame(bowlingGame, 20, 1);
            //act
            Score actualScore = bowlingGame.Score();
            //assert
            actualScore.Should().Be(score);
        }


        private void AddMultipleBallsToBowlingGame(BowlingGame bowlingGame, int numberToRoll, int scoreToAdd)
        {
            for (int ballsRolledCount = 0; ballsRolledCount < numberToRoll; ballsRolledCount++)
            {
                bowlingGame.BallRolled(new Ball(new Score(scoreToAdd)));
            }
        }

        private class Score : IScore
        {
            private readonly int _pinsHit;
            public Score(int pinsHit)
            {
                _pinsHit = pinsHit;
            }

            public override bool Equals(object obj) => Equals((Score)obj);
            private bool Equals(Score other) => GetHashCode() == other.GetHashCode();
            public override int GetHashCode() => _pinsHit;
            public static Score operator +(Score first, Score second) => new Score(first._pinsHit + second._pinsHit);
        }

        private class BowlingGame
        {
            private Score _totalScore = new Score(0);
            // ReSharper disable once MemberHidesStaticFromOuterClass
            internal Score Score() => new Score(0) + _totalScore;
            public void BallRolled(Ball pinsHit)
            {
                
                _totalScore += pinsHit.Score();
            }
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        private class Ball : IBall
        {
            private readonly Score _score;
            public Ball(Score score)
            {
                _score = score;
            }

            public override bool Equals(object obj) => Equals((Ball)obj);
            public static Score operator +(Ball first, Ball second) => first._score + second._score;
            private bool Equals(Ball other) => _score.Equals(other._score);
            public Score Score() => new Score(0) + _score;
        }
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        private interface IBall
        {
            bool Equals(object obj);
        }
        private interface IScore
        {
            bool Equals(object obj);
            int GetHashCode();
        }
    }
}
