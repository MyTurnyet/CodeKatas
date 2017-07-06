using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.StringTowerKata
{
    [TestClass]
    public class StringTower0705
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOneFloorCorrectly()
        {
            //act
            string[] layout = CreateTower(1);
            //assert
            layout.ShouldBeEquivalentTo(new[] { "*" });
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTwoFloorsCorrectly()
        {
            //act
            string[] layout = CreateTower(2);
            //assert
            layout.ShouldBeEquivalentTo(new[] { " * ", "***" });
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFourFloorsCorrectly()
        {
            //act
            string[] layout = CreateTower(4);
            //assert
            layout.ShouldBeEquivalentTo(new[] { "   *   ", "  ***  ", " ***** ", "*******" });
        }

        private string[] CreateTower(int numberOfFloors)
        {
            string[] floorLayout = new string[numberOfFloors];
            for (int currentFloor = numberOfFloors; currentFloor >= 1; currentFloor--)
            {
                int paddingWidth = numberOfFloors - currentFloor;
                string floorPadding = "".PadRight(paddingWidth);
                string floorPlan = floorPadding + "".PadRight(currentFloor + (currentFloor - 1), '*') + floorPadding;
                floorLayout[currentFloor - 1] = floorPlan;
            }
            return floorLayout;
        }
    }
}
