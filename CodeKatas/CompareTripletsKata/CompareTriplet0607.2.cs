using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.CompareTripletsKata
{
    [TestClass]
    public class CompareTriplet06072
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOneForWinA()
        {
            //act
            string score = Evaluate(3, 1);

            //assert
            score.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnZeroForNonWinA()
        {
            //act
            string score = Evaluate(1, 3);

            //assert
            score.Should().Be("0");
        }

        [TestMethod, TestCategory("Unit")]
        public void Blah()
        {
            int score1 = 0;
            int score2 = 0;

            //act
            Evaluate(1, 3, ref score1, ref score2);
            Evaluate(1, 3, ref score1, ref score2);
            Evaluate(1, 3, ref score1, ref score2);

            string score = $"{score1}_{score2}";

            //assert
            score.Should().Be("0_3");
        }

        [TestMethod, TestCategory("Unit")]
        public void BlahZeor()
        {
            int score1 = 0;
            int score2 = 0;

            //act
            Evaluate(3, 3, ref score1, ref score2);
            Evaluate(3, 3, ref score1, ref score2);
            Evaluate(3, 3, ref score1, ref score2);

            string score = $"{score1}_{score2}";

            //assert
            score.Should().Be("0_0");
        }

        private void Evaluate(int scoreA, int scoreB, ref int score1, ref int score2)
        {
            if (scoreA > scoreB) score1++;
            if (scoreA < scoreB) score2++;

        }

        private string Evaluate(int scoreA, int scoreB)
        {
            return scoreA > scoreB ? "1" : "0";
        }
    }
}
