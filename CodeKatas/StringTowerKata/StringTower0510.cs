using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.StringTowerKata
{
    [TestClass]
    public class StringTower0510
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOneTowerLevel()
        {
            //arrange
            string[] expectedOutput = new[] { "*" };
            //act
            string[] actualOutput = CreateTower(1);
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTwoTowerLevels()
        {
            //arrange
            string[] expectedOutput = new[] { " * ", "***" };
            //act
            string[] actualOutput = CreateTower(2);
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFourTowerLevels()
        {
            //arrange
            string[] expectedOutput = new[] { "   *   ", "  ***  ", " ***** ", "*******" };
            //act
            string[] actualOutput = CreateTower(4);
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }


        private string[] CreateTower(int numberOfFloors)
        {
            List<string> outputList = new List<string>();
            for (int currentFloorNumber = numberOfFloors; currentFloorNumber >= 1; currentFloorNumber--)
            {
                var padSize = PadSize(numberOfFloors, currentFloorNumber);
                outputList.Insert(0, SpacingString(padSize) + StarString(currentFloorNumber) + SpacingString(padSize));
            }
            return outputList.ToArray();
        }
        private string StarString(int currentFloorNumber) => "".PadRight(StarCount(currentFloorNumber), '*');
        private string SpacingString(int padSize) => "".PadRight(padSize, ' ');
        private int PadSize(int numberOfFloors, int currentFloorNumber) => numberOfFloors - currentFloorNumber;
        private int StarCount(int currentFloorNumber) => currentFloorNumber + (currentFloorNumber - 1);
    }
}
