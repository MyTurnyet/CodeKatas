using System.Collections.Generic;
using System.Linq;
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
            string[] expectedOutput = new[] { " * ","***" };
            //act
            string[] actualOutput = CreateTower(2);
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFourTowerLevels()
        {
            //arrange
            string[] expectedOutput = new[] { "   *   ","  ***  "," ***** ","*******" };
            //act
            string[] actualOutput = CreateTower(4);
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }


        private string[] CreateTower(int numberOfFloors)
        {
            List<string> outputList = new List<string>();
            Enumerable.Range(1, numberOfFloors).Reverse().ToList().ForEach(x=> outputList.Insert(0, AddFloor(x,PadSize(numberOfFloors,x))));
            return outputList.ToArray();
        }

        private string AddFloor(int currentFloorNumber, int padSize)=> SpacingString(padSize) + StarString(currentFloorNumber) + SpacingString(padSize);
        private string StarString(int currentFloorNumber) => "".PadRight(StarCount(currentFloorNumber), '*');
        private string SpacingString(int padSize) => "".PadRight(padSize, ' ');
        private int PadSize(int numberOfFloors, int currentFloorNumber) => numberOfFloors - currentFloorNumber;
        private int StarCount(int currentFloorNumber) => currentFloorNumber + (currentFloorNumber - 1);
    }
}
