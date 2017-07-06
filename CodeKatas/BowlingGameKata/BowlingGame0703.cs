using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.BowlingGameKata
{
    [TestClass]
    public class BowlingGame0703
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreGutterGame()
        {
            //arrange
            int[] pinsHit = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //act
            int totalScore = ScoreGame(pinsHit);
            //assert
            totalScore.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreAllOnesGame()
        {
            //arrange
            int[] pinsHit = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            //act
            int totalScore = ScoreGame(pinsHit);
            //assert
            totalScore.Should().Be(20);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreSpare()
        {
            //arrange
            int[] pinsHit = new[] { 5, 5, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //act
            int totalScore = ScoreGame(pinsHit);
            //assert
            totalScore.Should().Be(19);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreStrike()
        {
            //arrange
            int[] pinsHit = new[] { 10, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //act
            int totalScore = ScoreGame(pinsHit);
            //assert
            totalScore.Should().Be(26);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScorePerfectGame()
        {
            //arrange
            int[] pinsHit = new[] { 10,10,10,10,10,10,10,10,10,10,10,10 };
            //act
            int totalScore = ScoreGame(pinsHit);
            //assert
            totalScore.Should().Be(300);
        }

        private int ScoreGame(int[] pinsHit)
        {
            int score = 0;
            int numberOfballsRolled = pinsHit.Length;
            for (int currentPin = 0; currentPin < numberOfballsRolled; currentPin++)
            {
                if (score >= 300) break;
                int currentBallScore = pinsHit[currentPin];
                score += currentBallScore;
                if (currentPin > numberOfballsRolled - 3) continue;
                int nextBallScore = pinsHit[currentPin + 1];
                if (currentBallScore !=10 && currentBallScore + nextBallScore != 10) continue;
                score += nextBallScore + pinsHit[currentPin + 2];
                if (currentBallScore + nextBallScore != 10) continue;
                currentPin++;
            }
            return score;
        }
    }
}
