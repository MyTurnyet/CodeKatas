using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGameKata20170905
    {
        #region ball tests
        /// <summary>
        /// Ball Tests
        /// </summary>
        [TestMethod, TestCategory("Unit")]
        public void ShouldHaveEqualBallScore()
        {
            //arrange
            Ball ball1 = new Ball(0);
            Ball ball2 = new Ball(0);
            //act
            ball1.Should().Be(ball2);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotHaveEqualBallScore()
        {
            //arrange
            Ball ball1 = new Ball(0);
            Ball ball2 = new Ball(1);
            //act
            ball1.Should().NotBe(ball2);
        }
        #endregion ball tests

        #region Score tests
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnScoreObjectWithScore0()
        {
            //arrange
            Ball ball1 = new Ball(0);

            //act
            Score score = ball1.Score();

            //assert
            score.Should().Be(new Score(0));
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotBeScore()
        {
            //arrange
            Score score1 = new Score(0);
            Score score2 = new Score(1);

            //assert
            score1.Should().NotBe(score2);
        }
        #endregion Score tests

        #region Frame tests
        /// <summary>
        /// Frame Tests
        /// </summary>
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFrameScore()
        {
            //arrange
            Ball ball1 = new Ball(4);
            Ball ball2 = new Ball(3);
            RegularFrame frame = new RegularFrame(ball1, ball2);
            Score score2 = new Score(7);
            //act
            Score frameScore = frame.Score();

            //assert
            frameScore.Should().Be(score2);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTrueIfSpare()
        {
            //arrange
            Ball ball1 = new Ball(6);
            Ball ball2 = new Ball(4);
            IFrame frame = new SpareFrame(ball1, ball2);

            //act
            bool isSpare = frame.IsSpare();
            //assert
            isSpare.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTrueIfStrike()
        {
            //arrange
            IFrame frame = new StrikeFrame();

            //act
            bool isSpare = frame.IsStrike();
            //assert
            isSpare.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldGetAdditionAllBallScoreForSpare()
        {
            //arrange
            IFrame frame1 = new SpareFrame(new Ball(6), new Ball(4));
            IFrame frame2 = new RegularFrame(new Ball(3), new Ball(3));
            Score expectedScore = new Score(13);
            frame1.AddNextFrame(frame2);
            //act
            Score actualScore = frame1.Score();
            //assert
            actualScore.Should().Be(expectedScore);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldGetAdditionAllBallScoreForStrike()
        {
            //arrange
            IFrame frame1 = new StrikeFrame();
            IFrame frame2 = new RegularFrame(new Ball(4), new Ball(3));
            Score expectedScore = new Score(17);
            frame1.AddNextFrame(frame2);
            //act
            Score actualScore = frame1.Score();
            //assert
            actualScore.Should().Be(expectedScore);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldGetAdditionAllBallScoreForStrikeIn10ThFrame()
        {
            //arrange
            IFrame frame1 = new StrikeFrame();
            frame1.AddBonusBalls(new BonusBall(10), new BonusBall(5));
            Score expectedScore = new Score(25);
            //act
            Score actualScore = frame1.Score();
            //assert
            actualScore.Should().Be(expectedScore);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldnotGetBonusBallScoreForStrikeNotIn10ThFrame()
        {
            //arrange
            IFrame frame1 = new StrikeFrame();
            IFrame frame3 = new RegularFrame(new Ball(3), new Ball(3));
            frame1.AddNextFrame(frame3);
            frame1.AddBonusBalls(new BonusBall(10), new BonusBall(5));
            Score expectedScore = new Score(16);
            //act
            Score actualScore = frame1.Score();
            //assert
            actualScore.Should().Be(expectedScore);
        }
        #endregion Frame tests

        #region Game tests
        /// <summary>
        /// Game Tests
        /// </summary>
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            Game game = new Game();
            AddFramesWithScore(game, 10);
            Score expectedScore = new Score(0);
            //act
            Score actualScore = game.ScoreGame();

            //assert
            actualScore.Should().Be(expectedScore);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGamewithAllOnes()
        {
            //arrange
            Game game = new Game();
            AddFramesWithScore(game, 10, 1);
            Score expectedScore = new Score(20);
            //act
            Score actualScore = game.ScoreGame();

            //assert
            actualScore.Should().Be(expectedScore);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGameWithSpare()
        {
            //arrange
            Game game = new Game();
            IFrame frame1 = new SpareFrame(new Ball(4), new Ball(6));
            IFrame frame2 = new RegularFrame(new Ball(3), new Ball(3));
            game.AddFrame(frame1);
            game.AddFrame(frame2);
            AddFramesWithScore(game, 8, 0);
            Score expectedScore = new Score(19);

            //act
            Score actualScore = game.ScoreGame();

            //assert
            actualScore.Should().Be(expectedScore);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGameWithStrike()
        {
            //arrange
            Game game = new Game();
            IFrame strikeFrame = new StrikeFrame();
            IFrame frame2 = new RegularFrame(new Ball(3), new Ball(4));
            game.AddFrame(strikeFrame);
            game.AddFrame(frame2);
            AddFramesWithScore(game, 8);
            Score expectedScore = new Score(24);
            //act
            Score actualScore = game.ScoreGame();
            //assert
            actualScore.Should().Be(expectedScore);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreStrikeAtTheEnd()
        {
            Game game = new Game();
            AddFramesWithScore(game, 9, 1);
            IFrame strikeFrame = new StrikeFrame();
            strikeFrame.AddBonusBalls(new BonusBall(3), new BonusBall(6));
            game.AddFrame(strikeFrame);
            Score expectedScore = new Score(37);
            //act
            Score actualScore = game.ScoreGame();
            //assert
            actualScore.Should().Be(expectedScore);
        }
        #endregion Game tests

        /// <summary>
        /// Helper Functions
        /// </summary>
        private void AddFramesWithScore(Game game, int numberOfFrames, int pinsHitPerBall = 0)
        {
            for (int i = 0; i < numberOfFrames; i++)
            {
                game.AddFrame(new RegularFrame(new Ball(pinsHitPerBall), new Ball(pinsHitPerBall)));
            }
        }

        /// <summary>
        /// Nested Classes
        /// </summary>
        private interface IFrame
        {
            void AddNextFrame(IFrame nextFrame);
            bool IsSpare();
            bool IsStrike();
            Score Score();
            Score GetBonusScore(IFrame frame);
            void AddBonusBalls(BonusBall bonusBall1, BonusBall bonusBall2);
        }

        private class Game
        {
            private readonly List<IFrame> _frames = new List<IFrame>();
            public void AddFrame(IFrame nextFrame)
            {
                int framesCount = _frames.Count;
                if (framesCount > 0)
                {
                    _frames[framesCount - 1].AddNextFrame(nextFrame);
                }
                _frames.Add(nextFrame);
            }

            public Score ScoreGame()
            {
                Score totalScore = new Score(0);
                for (int frameNumber = 0; frameNumber < _frames.Count; frameNumber++)
                {
                    var frame = _frames[frameNumber];
                    totalScore += frame.Score();
                }
                return totalScore;
            }
        }
        private class StrikeFrame : IFrame
        {
            private IFrame _nextFrame;
            private readonly Ball _ball = new Ball(10);
            private BonusBall _bonusBall;
            private BonusBall _bonusBall2;
            public void AddNextFrame(IFrame nextFrame) => _nextFrame = nextFrame;
            public bool IsSpare() => false;
            public bool IsStrike() => true;
            public Score Score()
            {
                Score score = AddNextFrameBonus();
                return _ball.Score() + score;
            }

            private Score AddNextFrameBonus()
            {
                if (_nextFrame == null) return BonusBallScore();
                return _nextFrame.GetBonusScore(this);
            }

            private Score BonusBallScore()
            {
                return _bonusBall.Score() + _bonusBall2.Score();
            }

            public Score GetBonusScore(IFrame frame)
            {
                throw new NotImplementedException();
            }

            public void AddBonusBalls(BonusBall bonusBall1, BonusBall bonusBall2)
            {
                _bonusBall = bonusBall1;
                _bonusBall2 = bonusBall2;
            }
        }
        private class SpareFrame : IFrame
        {
            private readonly Ball _ball1;
            private readonly Ball _ball2;
            private IFrame _nextFrame;
            private BonusBall _bonusBall;
            private BonusBall _bonusBall2;

            public SpareFrame(Ball ball1, Ball ball2)
            {
                if (!Equals(ball1.Score() + ball2.Score(), new Score(10))) throw new ArgumentException("The score of two balls in rolled in a spare frame must be 10");
                _ball1 = ball1;
                _ball2 = ball2;
            }

            public Score Score()
            {
                return _ball1.Score() + _ball2.Score() + _nextFrame.GetBonusScore(this);
            }

            public Score GetBonusScore(IFrame frame)
            {
                throw new NotImplementedException();
            }

            public void AddBonusBalls(BonusBall bonusBall1, BonusBall bonusBall2)
            {
                _bonusBall = bonusBall1;
                _bonusBall2 = new BonusBall(0);
            }

            public bool IsSpare() => true;
            public void AddNextFrame(IFrame nextFrame) => _nextFrame = nextFrame;
            public bool IsStrike() => false;
        }
        private class RegularFrame : IFrame
        {
            private readonly Ball _ball1;
            private readonly Ball _ball2;
            private IFrame _nextFrame;

            public RegularFrame(Ball ball1, Ball ball2)
            {
                _ball1 = ball1;
                _ball2 = ball2;
            }

            public Score Score() => _ball1.Score() + _ball2.Score();
            public Score GetBonusScore(IFrame frame) => frame.IsSpare() ? _ball1.Score() : Score();
            public void AddBonusBalls(BonusBall bonusBall1, BonusBall bonusBall2) { }
            public bool IsSpare() => false;
            public void AddNextFrame(IFrame nextFrame) => _nextFrame = nextFrame;
            public bool IsStrike() => false;
        }

        private class Score
        {
            private readonly int _points;

            public Score(int points)
            {
                _points = points;
            }

            public override bool Equals(object obj) => obj != null && _points.Equals(((Score)obj)._points);
            protected bool Equals(Score other) => _points == other._points;
            public override int GetHashCode() => _points;
            public static Score operator +(Score firstScore, Score secondScore) => new Score(firstScore._points + secondScore._points);
        }

        private class Ball
        {
            private readonly int _pinsHit;

            public Ball(int pinsHit)
            {
                _pinsHit = pinsHit;
            }

            public override bool Equals(object other) => other != null && this._pinsHit.Equals(((Ball)other)._pinsHit);
            protected bool Equals(Ball other) => _pinsHit == other._pinsHit;
            public override int GetHashCode() => _pinsHit;
            public Score Score() => new Score(_pinsHit);
        }
        private class BonusBall : Ball
        {
            public BonusBall(int pinsHit) : base(pinsHit) { }
        }
    }
}
