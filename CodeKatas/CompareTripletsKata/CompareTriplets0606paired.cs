using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.CompareTripletsKata
{
    [TestClass]
    public class CompareTriplets0606Paired
    {
        
        [TestMethod, TestCategory("Unit")]
        public void AshouldWin()
        {
            //arrange
            int a = 5;
            int b = 3;
            //act
           
            //assert
            int result = GetAScore(a, b);
            result.Should().Be(1);
        }
        [TestMethod, TestCategory("Unit")]
        public void AshouldLose()
        {
            //arrange
            int a = 3;
            int b = 5;
            //act

            //assert
            int result = GetAScore(a, b);
            result.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void BshouldWin()
        {
            //arrange
            int a = 3;
            int b = 5;
            //act
            int result = GetBScore(a, b);
            //assert
            result.Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void BShouldLose()
        {
            //arrange
            int a = 5;
            int b = 3;
            //act
            int result = GetBScore(a, b);
            //assert
            result.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldIterateArrayWhereBWins()
        {
            //arrange
            int[] a = new[] { 0 };
            int[] b = new[] { 3 };
            //act
            string result = IterateArrays(a, b);
            //assert
            result.Should().Be("0_1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldIterateArrayAandBNoneWins()
        {
            //arrange
            int[] a = new[] { 1,1,1 };
            int[] b = new[] { 1,1,1, };
            //act
            string result = IterateArrays(a, b);
            //assert
            result.Should().Be("0_0");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldIterateArrayWhereAWins()
        {
            //arrange
            int[] a = new[] {1};
            int[] b = new[] {0};
            //act
            string result = IterateArrays(a, b);
            //assert
            result.Should().Be("1_0");
        }

        private string IterateArrays(int[] aScoreArray, int[] bScoreArray)
        {
            int numberOfAWins = 0;
            int numberOfBWins = 0;
            for (int currentIndex = 0; currentIndex < aScoreArray.Length; currentIndex++)
            {
                numberOfAWins += GetAScore(aScoreArray[currentIndex], bScoreArray[currentIndex]);
                numberOfBWins += GetBScore(aScoreArray[currentIndex], bScoreArray[currentIndex]);
            }
            return $"{numberOfAWins}_{numberOfBWins}";
        }

        private int GetBScore(int a, int b) => (b > a)? 1:0;

        private int GetAScore(int a, int b) => (a > b)?1:0;
    }
}
