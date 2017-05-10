using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.CompareTripletsKata
{
    [TestClass]
    public class CompareTriplets0509Mob
    {
        [TestMethod, TestCategory("Unit")]
        public void ASnouldWin()
        {
            //arrange
            int scoreForPersonA = 5;
            int scoreForPersonB = 3;

            //act
            int returnValue = ScoreTestForA(scoreForPersonA, scoreForPersonB);
            //assert
            returnValue.Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void BSnouldWin()
        {
            //arrange
            int scoreForPersonA = 3;
            int scoreForPersonB = 5;

            //act
            int returnValue = ScoreTestForA(scoreForPersonA, scoreForPersonB);
            //assert
            returnValue.Should().Be(-1);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldTie()
        {
            //arrange
            int scoreForPersonA = 3;
            int scoreForPersonB = 3;

            //act
            int returnValue = ScoreTestForA(scoreForPersonA, scoreForPersonB);
            //assert
            returnValue.Should().Be(0);
        }

        private int ScoreTestForA(int scoreForPersonA, int scoreForPersonB)
        {
            if (scoreForPersonA == scoreForPersonB) return 0;

            if (scoreForPersonA < scoreForPersonB) return -1;

            return 1;
        }

        [TestMethod, TestCategory("Unit")]
        public void PersonAShouldWinAll()
        {
            //arrange
            List<int> scoresForPersonA = new List<int> {5, 5, 5};
            List<int> scoresForPersonB = new List<int> { 3, 3, 3 };

            //act
            string returnValue = CompareScores(scoresForPersonA, scoresForPersonB);
            //assert
            returnValue.Should().Be("3 0");
        }

        [TestMethod, TestCategory("Unit")]
        public void PersonBShouldWinAll()
        {
            //arrange
            List<int> scoresForPersonA = new List<int> { 3, 3, 3 };
            List<int> scoresForPersonB = new List<int> { 5, 5, 5};

            //act
            string returnValue = CompareScores(scoresForPersonA, scoresForPersonB);
            //assert
            returnValue.Should().Be("0 3");
        }

        [TestMethod, TestCategory("Unit")]
        public void OneWinForPersonAAndPersonB()
        {
            //arrange
            List<int> scoresForPersonA = new List<int> { 5, 1, 3 };
            List<int> scoresForPersonB = new List<int> { 3, 1, 5 };

            //act
            string returnValue = CompareScores(scoresForPersonA, scoresForPersonB);
            //assert
            returnValue.Should().Be("1 1");
        }

        private string CompareScores(List<int> scoresForPersonA, List<int> scoresForPersonB)
        {
            int winsForA = 0;
            int winsForB = 0;
            for (int i = 0; i < scoresForPersonA.Count; i++)
            {
                int PersonAScore = scoresForPersonA[i];
                int  PersonBScore = scoresForPersonB[i];
                if (PersonAScore > PersonBScore) winsForA++;
                if (PersonBScore > PersonAScore) winsForB++;

            }
            return $"{winsForA} {winsForB}";
        }

    }
}
