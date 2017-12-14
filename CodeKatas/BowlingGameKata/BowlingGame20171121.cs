using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGame20171121
    {
        [TestMethod, TestCategory("Unit")]
        public void BallShouldHaveScoreOf1()
        {
            //arrange
            Ball ball = new Ball(0);
            //act
            int score = ball.Score();
            //assert
            score.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            var balls = new List<Ball>
            {
                new Ball(0),
                new Ball(0),
                new Ball(0),
                new Ball(0)
            };
            Game game = new Game(balls);
            //act
            int totalScore = game.Score();
            //assert
            totalScore.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAllSinglePins()
        {
            //arrange
            var balls = new List<Ball>
            {
                new Ball(1),
                new Ball(1),
                new Ball(1),
                new Ball(1)
            };
            Game game = new Game(balls);
            //act
            int totalScore = game.Score();
            //assert
            totalScore.Should().Be(4);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreSpare()
        {
            //arrange
            var balls = new List<Ball>
            {
                new Ball(6),
                new Ball(4),
                new Ball(3),
                new Ball(4)
            };
            Game game = new Game(balls);
            //act
            int totalScore = game.Score();
            //assert
            totalScore.Should().Be(20);
        }

        private class Ball
        {
            private readonly int _score;

            public Ball(int score)
            {
                _score = score;
            }

            public int Score()
            {
                return _score;
            }
        }

        private class Game
        {
            private readonly List<Ball> _balls;

            public Game(List<Ball> balls)
            {
                _balls = balls;
            }

            public int Score()
            {
                int sum = 0;
                int ballCount = _balls.Count;
                for (int currentBall = 0; currentBall < ballCount; currentBall++)
                {
                    Ball ball = _balls[currentBall];
                    sum += ball.Score();
                    if (currentBall + 2 > ballCount) continue;
                    Ball nextBall = _balls[currentBall + 1];
                    if (ball.Score() + nextBall.Score() != 10) continue;
                    Ball ballAfterNext = _balls[currentBall + 2];
                    sum += nextBall.Score() + ballAfterNext.Score();
                    currentBall++;
                }
                return sum;
            }
        }
    }
}
