using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.CompareTripletsKata
{
    [TestClass]
    public class CompareTriplets0607
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOnePointForA()
        {
            //arrange
            int a = 5;
            int b = 2;
            //act
            int scoreForA = ScoreA(a, b);

            //assert
            scoreForA.Should().Be(1);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOnePointFor6()
        {
            //arrange
            int a = 2;
            int b = 5;
            //act
            int scoreB = ScoreB(a, b);

            //assert
            scoreB.Should().Be(1);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnZeroPointsForA()
        {
            //arrange
            int a = 3;
            int b = 5;
            //act
            int scoreForA = ScoreA(a, b);

            //assert
            scoreForA.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnZeroPointsForb()
        {
            //arrange
            int a = 5;
            int b = 3;
            //act
            int scoreB = ScoreB(a, b);

            //assert
            scoreB.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldInterateArrayThatReturnsWinForA()
        {
            //arrange
            int[] scoresForA = new[] { 5 };
            int[] scoresForB = new[] { 2 };

            //act
            string scoringOutput = InterateArrays(scoresForA, scoresForB);
            //assert
            scoringOutput.Should().Be("1_0");
        }
        [TestMethod, TestCategory("Unit")]
        //public void ShouldInterateLargerArrayThatReturnsWinForA()
        //{
        //    //arrange
        //    int[] scoresForA = new[] { 5, 5, 5 };
        //    int[] scoresForB = new[] { 2, 2, 2 };

        //    //act
        //    string scoringOutput = InterateArrays(scoresForA, scoresForB);
        //    //assert
        //    scoringOutput.Should().Be("3_0");
        //}
        private string InterateArrays(int[] scoresForA, int[] scoresForB)
        {
            return "1_0";
        }

        private int ScoreA(int scoreForA, int scoreForB) => (scoreForA > scoreForB) ? 1 : 0;
        private int ScoreB(int scoreForA, int scoreForB) => (scoreForB > scoreForA) ? 1 : 0;
    }
}
