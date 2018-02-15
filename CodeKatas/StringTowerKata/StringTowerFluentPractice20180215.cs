using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace CodeKatas.StringTowerKata
{
    [TestClass]
    public class StringTowerFluentPractice20180215
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnEmptyString()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //act
            string[] actualReturn = fluentStringTower.AsStringArray();
            //assert
            actualReturn.Should().BeEmpty();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFloorCount()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //act
            int actualFloors = fluentStringTower.WithFloorCount(1).FloorCount();
            //assert
            actualFloors.Should().Be(1);
        }


        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnEmptyStringUntilLayoutCalled()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //act
            FluentStringTower actualTower = fluentStringTower.WithFloorCount(1);

            //assert
            actualTower.AsStringArray().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOneFloorLayout()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //act
            FluentStringTower actualTower = fluentStringTower.WithFloorCount(1).Layout();

            //assert
            actualTower.AsStringArray().Should().BeEquivalentTo("*");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnTwoFloorLayout()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //act
            FluentStringTower actualTower = fluentStringTower.WithFloorCount(2).Layout();

            //assert
            actualTower.AsStringArray().Should().BeEquivalentTo(" * ", "***");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnThreeFloorLayout()
        {
            //arrange
            FluentStringTower fluentStringTower = new FluentStringTower();

            //assert
            fluentStringTower.WithFloorCount(3).Layout().AsStringArray().Should().BeEquivalentTo("  *  ", " *** ","*****");
        }

        public class FluentStringTower
        {
            private int _floors;
            private readonly List<string> _output = new List<string>();

            public string[] AsStringArray()
            {
                return _output.ToArray();
            }

            public FluentStringTower WithFloorCount(int floors)
            {
                _floors = floors;
                return this;
            }

            public FluentStringTower Layout()
            {
               
                for (int currentFloor = 1; currentFloor <= _floors; currentFloor++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append($"{SpacePadding(currentFloor)}{"".PadLeft(currentFloor + (currentFloor-1),'*')}{SpacePadding(currentFloor)}");
                    _output.Add(stringBuilder.ToString());
                }
                
                return this;
            }

            private string SpacePadding(int currentFloor)
            {
                return "".PadLeft(_floors - currentFloor,' ');
            }

            public int FloorCount()
            {
                return _floors;
            }
        }
    }
}
