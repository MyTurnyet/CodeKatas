using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.CompareTripletsKata
{
    [TestClass]
    public class CompareTriplets0505
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreBothTied()
        {
            //arrange
            int a0 = 0;
            int a1 = 0;
            int a2 = 0;
            int b0 = 0;
            int b1 = 0;
            int b2 = 0;
            string expectedOutcome = "0 0";
            CompareTriplets compare = new CompareTriplets(a0,a1,a2,b0,b1,b2);

            //act
            string score = compare.Outcome();

            //assert
            score.Should().Be(expectedOutcome);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreWinnerA()
        {
            //arrange
            int a0 = 5;
            int a1 = 6;
            int a2 = 7;
            int b0 = 1;
            int b1 = 2;
            int b2 = 3;
            string expectedOutcome = "3 0";
            CompareTriplets compare = new CompareTriplets(a0, a1, a2, b0, b1, b2);

            //act
            string score = compare.Outcome();

            //assert
            score.Should().Be(expectedOutcome);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreWinnerB()
        {
            //arrange
            int a0 = 1;
            int a1 = 2;
            int a2 = 3;
            int b0 = 4;
            int b1 = 5;
            int b2 = 6;
            string expectedOutcome = "0 3";
            CompareTriplets compare = new CompareTriplets(a0, a1, a2, b0, b1, b2);

            //act
            string score = compare.Outcome();

            //assert
            score.Should().Be(expectedOutcome);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldScoreBothSides()
        {
            //arrange
            int a0 = 1;
            int a1 = 3;
            int a2 = 5;
            int b0 = 4;
            int b1 = 3;
            int b2 = 1;
            string expectedOutcome = "1 1";
            CompareTriplets compare = new CompareTriplets(a0, a1, a2, b0, b1, b2);

            //act
            string score = compare.Outcome();

            //assert
            score.Should().Be(expectedOutcome);
        }

        private class CompareTriplets
        {
            private int a0;
            private int a1;
            private int a2;
            private int b0;
            private int b1;
            private int b2;

            public CompareTriplets(int a0, int a1, int a2, int b0, int b1, int b2)
            {
                this.a0 = a0;
                this.a1 = a1;
                this.a2 = a2;
                this.b0 = b0;
                this.b1 = b1;
                this.b2 = b2;
            }

            public string Outcome()=> $"{ScoreA()} {ScoreB()}";

            private int ScoreB()
            {
                int bScore=0;
                if (a0 < b0) bScore++;
                if (a1 < b1) bScore++;
                if (a2 < b2) bScore++;
                return bScore;
            }

            private int ScoreA()
            {
                int aScore =0;
                if (a0 > b0) aScore++;
                if (a1 > b1) aScore++;
                if (a2 > b2) aScore++;
                return aScore;
            }
        }
    }
}
