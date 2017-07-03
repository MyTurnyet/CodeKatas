using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.StringTowerKata
{
    [TestClass]
    public class StringTower0626
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOneAsteriskForOneFloor()
        {
            //act
            string[] floorLayout = CreateTowerFloors(1);
            //assert
            floorLayout.Should().BeEquivalentTo(new string[] { "*" });
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTwoFloorArray()
        {
            //act
            string[] floorLayout = CreateTowerFloors(2);
            //assert
            floorLayout.Should().BeEquivalentTo(new string[] { " * ", "***" });
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFourFloorArray()
        {
            //act
            string[] floorLayout = CreateTowerFloors(4);
            //assert
            floorLayout.Should().BeEquivalentTo(new string[] { "   *   ", "  ***  ", " ***** ", "*******" });
        }
        private string[] CreateTowerFloors(int totalFloors)
        {
            string[] towerLayout = new string[totalFloors];
            for (int floorIndex = totalFloors; floorIndex >= 1; floorIndex--)
            {
                string floor = "".PadLeft(NumberOfStars(floorIndex), '*');
                floor = PadString(totalFloors, floorIndex) + floor + PadString(totalFloors, floorIndex);
                towerLayout[floorIndex - 1] = floor;
            }
            return towerLayout;
        }
        private string PadString(int totalFloors, int floorIndex) => "".PadRight(PaddingCount(totalFloors, floorIndex));
        private int PaddingCount(int totalFloors, int floorIndex) => totalFloors - floorIndex;
        private int NumberOfStars(int floorIndex) => floorIndex + (floorIndex - 1);
    }
}
