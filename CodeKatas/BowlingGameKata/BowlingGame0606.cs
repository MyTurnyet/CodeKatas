using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGame0606
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            int[] ballsRolled = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int score = ScoreGame(ballsRolled);
            //assert
            score.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAllOnes()
        {
            //arrange
            int[] ballsRolled = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //act
            int score = ScoreGame(ballsRolled);

            //assert
            score.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreSpare()
        {
            //arrange
            int[] ballsRolled = new[] { 5, 5, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int score = ScoreGame(ballsRolled);
            //assert
            score.Should().Be(20);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreStrike()
        {
            //arrange
            int[] ballsRolled = new[] { 10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int score = ScoreGame(ballsRolled);
            //assert
            score.Should().Be(24);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScorePerfectGame()
        {
            //arrange
            int[] ballsRolled = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            //act
            int score = ScoreGame(ballsRolled);
            //assert
            score.Should().Be(300);
        }

        private int ScoreGame(int[] ballsRolled)
        {
            int totalScore = 0;
            int numberOfBallsRolled = ballsRolled.Length;
            for (int currentBallNumber = 0; currentBallNumber < numberOfBallsRolled; currentBallNumber++)
            {
                if (totalScore == 300) break;
                int currentBallScore = ballsRolled[currentBallNumber];
                totalScore += currentBallScore;
                if (!CanScoreExtraBalls(currentBallNumber, numberOfBallsRolled)) continue;
                int nextBallScore = ballsRolled[currentBallNumber + 1];
                if (!IsStrike(currentBallScore) && !IsSpare(currentBallScore, nextBallScore)) continue;
                totalScore += nextBallScore + ballsRolled[currentBallNumber + 2];
                if (IsStrike(currentBallScore)) continue;
                currentBallNumber++;
            }
            return totalScore;
        }

        private bool CanScoreExtraBalls(int currentBallNumber, int numberOfBallsRolled)
        {
            return currentBallNumber <= numberOfBallsRolled - 2;
        }

        private bool IsSpare(int currentBallScore, int nextBallScore) => currentBallScore + nextBallScore == 10;
        private bool IsStrike(int currentBallScore) => currentBallScore == 10;
    }
}
