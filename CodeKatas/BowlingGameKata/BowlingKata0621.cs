using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingKata0621
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            int[] ballsRolled = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int totalScore = GetBowlingScore(ballsRolled);

            //assert
            totalScore.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGameOfOnePinPerRoll()
        {
            //arrange
            int[] ballsRolled = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //act
            int totalScore = GetBowlingScore(ballsRolled);

            //assert
            totalScore.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreASpareFrame()
        {
            //arrange
            int[] ballsRolled = new[] { 5, 5, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int totalScore = GetBowlingScore(ballsRolled);

            //assert
            totalScore.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAStrikeFrame()
        {
            //arrange
            int[] ballsRolled = new[] { 10, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //act
            int totalScore = GetBowlingScore(ballsRolled);

            //assert
            totalScore.Should().Be(28);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAPerfectGame()
        {
            //arrange
            int[] ballsRolled = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            //act
            int totalScore = GetBowlingScore(ballsRolled);

            //assert
            totalScore.Should().Be(300);
        }
        private int GetBowlingScore(int[] ballsRolled)
        {
            int score = 0;
            int numberOfBallsRolled = ballsRolled.Length;
            for (int currentBall = 0; currentBall < numberOfBallsRolled; currentBall++)
            {
                if (score >= 300) break;
                int currentPinsHit = ballsRolled[currentBall];
                score += currentPinsHit;
                if ((currentBall >= numberOfBallsRolled - 2)) continue;
                int nextPinsHit = ballsRolled[currentBall + 1];
                bool isSpare = currentPinsHit + nextPinsHit != 10;
                if (isSpare && currentPinsHit != 10) continue;
                score += nextPinsHit + ballsRolled[currentBall + 2];
                if (isSpare) continue;
                currentBall++;
            }
            return score;
        }
    }
}
