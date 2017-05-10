using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGame20170504
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //assign
            BowlingGame game = new BowlingGame();

            //act
            int score = game.TotalScore(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            //assert
            score.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAllOnes()
        {
            //assign
            BowlingGame game = new BowlingGame();

            //act
            int score = game.TotalScore(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            //assert
            score.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreSpare()
        {
            //assign
            BowlingGame game = new BowlingGame();

            //act
            int score = game.TotalScore(new[] { 5, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            //assert
            score.Should().Be(16);

        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreStrike()
        {
            //assign
            BowlingGame game = new BowlingGame();

            //act
            int score = game.TotalScore(new[] { 10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            //assert
            score.Should().Be(24);

        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScorePerfectGame()
        {
            //assign
            BowlingGame game = new BowlingGame();

            //act
            int score = game.TotalScore(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            //assert
            score.Should().Be(300);

        }


        private class BowlingGame
        {
            public int TotalScore(IReadOnlyList<int> pinsHit)
            {
                int score = 0;
                int numberOfBallsRolled = pinsHit.Count;
                for (int currentBallNumber = 0; currentBallNumber < numberOfBallsRolled; currentBallNumber++)
                {
                    if (score == 300) break;
                    int currentBallScore = pinsHit[currentBallNumber];
                    score += currentBallScore;
                    if (!CanScoreBonus(currentBallNumber, numberOfBallsRolled)) continue;
                    int nextBallScore = pinsHit[currentBallNumber + 1];
                    if (!IsStrike(currentBallScore) &&!IsSpare(currentBallScore, nextBallScore)) continue;
                    int secondBallScore = pinsHit[currentBallNumber + 2];
                    score += ScoreNextTwoBalls(nextBallScore, secondBallScore);
                    if(!IsSpare(currentBallScore, nextBallScore))continue;
                    currentBallNumber++;
                }
                return score;
            }
            private int ScoreNextTwoBalls(int nextBallScore, int secondBallScore)=>nextBallScore + secondBallScore;
            private bool IsStrike(int currentBallScore)=>currentBallScore == 10;
            private bool IsSpare(int currentBallScore, int nextBallScore)=>currentBallScore + nextBallScore == 10;
            private bool CanScoreBonus(int currentBallNumber, int numberOfBallsRolled)=>(currentBallNumber <= numberOfBallsRolled - 3);
        }
    }
}
