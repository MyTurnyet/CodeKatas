using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{

    [TestClass]
    public class BowlingGameBallTests0717
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            List<Ball> balls = MultipleRolledBallsList(20, 0);
            BowlingGame game = new BowlingGame(balls);
            //act
            int score = game.TotalScore();
            //assert
            score.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGameOfAllOnes()
        {
            //arrange
            List<Ball> balls = MultipleRolledBallsList(20, 1);
            BowlingGame game = new BowlingGame(balls);
            //act
            int score = game.TotalScore();
            //assert
            score.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreSpare()
        {
            List<Ball> balls = new List<Ball>
            {
                new Ball(5),
                new Ball(5),
                new Ball(4),
                new Ball(3)
            };
            balls.AddRange(MultipleRolledBallsList(16, 0));
            BowlingGame game = new BowlingGame(balls);
            //act
            int score = game.TotalScore();
            //assert
            score.Should().Be(22);
        }

        private List<Ball> MultipleRolledBallsList(int numberOfBalls, int pinsHitPerBall)
        {
            List<Ball> balls = new List<Ball>();
            for (int ballnumber = 0; ballnumber < numberOfBalls; ballnumber++)
            {
                balls.Add(new Ball(pinsHitPerBall));
            }
            return balls;
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldBeEqual()
        {
            //arrange
            Ball ball1 = new Ball(4);
            Ball ball2 = new Ball(4);

            //assert
            ball2.Should().Be(ball1);
            (ball2 == ball1).Should().BeTrue();
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldBeNotEqual()
        {
            //arrange
            Ball ball1 = new Ball(4);
            Ball ball2 = new Ball(7);

            //assert
            ball2.Should().NotBe(ball1);
            (ball2 != ball1).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCorrectScore()
        {
            //arrange
            Ball ball = new Ball(4);

            //assert
            ball.Score().Should().Be(4);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnIsStrike()
        {
            //arrange
            Ball ball = new Ball(10);

            //assert
            ball.IsStrike().Should().BeTrue();
        }

        private class BowlingGame
        {
            private readonly List<Ball> _balls;

            public BowlingGame(List<Ball> balls)
            {
                _balls = balls;
            }

            public int TotalScore()
            {
                int totalScore = 0;
                for (int ballIndex = 0; ballIndex < _balls.Count; ballIndex++)
                {
                    totalScore += _balls[ballIndex].Score();
                    if (ballIndex < _balls.Count - 1)
                    {
                        if (_balls[ballIndex].Score() + _balls[ballIndex + 1].Score() == 10)
                        {
                            totalScore += _balls[ballIndex].Score();
                        }
                    }
                }
                return totalScore;
            }
        }

        private class Ball
        {
            private readonly int _pinsHit;

            public Ball(int pinsHit)
            {
                _pinsHit = pinsHit;
            }

            public static bool operator ==(Ball self, Ball other)
            {
                return other.Equals(self);
            }

            public static bool operator !=(Ball self, Ball other)
            {
                return !(self == other);
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                return ((Ball)obj).Equals(this);
            }

            private bool Equals(Ball other)
            {
                return _pinsHit == other._pinsHit;
            }

            public override int GetHashCode()
            {
                return _pinsHit.GetHashCode();
            }

            public int Score()
            {
                return _pinsHit;
            }

            public bool IsStrike()
            {
                return true;
            }
        }
    }
}
