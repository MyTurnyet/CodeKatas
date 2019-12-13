using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas._100DoorsKata
{
    [TestClass]
    public class HundredDoors20191130
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldShowDoorAs_Closed()
        {
            //assign
            IDoor door = new ClosedDoor();
            //act
            bool isOpen = door.IsOpen();

            //assert
            isOpen.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldShowDoorAs_Open()
        {
            //assign
            IDoor door = new OpenDoor();
            //act
            bool isOpen = door.IsOpen();

            //assert
            isOpen.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldHallwayShouldHave_1_OpenDoor()
        {
            //assign
            List<IDoor> doors = new List<IDoor> {new OpenDoor()};
            Hallway hallway = new Hallway(doors);
            //act
            int openDoorCount = hallway.NumberOfOpenDoors();
            //assert
            openDoorCount.Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldHallwayShouldHave_0_OpenDoors()
        {
            //assign
            List<IDoor> doors = new List<IDoor> {new ClosedDoor()};
            Hallway hallway = new Hallway(doors);
            //act
            int openDoorCount = hallway.NumberOfOpenDoors();
            //assert
            openDoorCount.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnOpenDoorOnStateChange()
        {
            //assign
            IDoor closedDoor = new ClosedDoor();
            //act
            IDoor openDoor = closedDoor.ChangeState();
            //assert
            openDoor.IsOpen().Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnClosedDoorOnStateChange()
        {
            //assign
            IDoor openDoor = new OpenDoor();
            //act
            IDoor closedDoor = openDoor.ChangeState();
            //assert
            closedDoor.IsOpen().Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldChangeStateOfDoor()
        {
            //assign
            List<IDoor> doors = new List<IDoor> {new OpenDoor()};
            Hallway hallway = new Hallway(doors);
            //act
            hallway.NumberOfOpenDoors().Should().Be(1);
            hallway.ChangeState(1);
            //assert
            hallway.NumberOfOpenDoors().Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldChangeStateOfDoors_WhenOpen()
        {
            //assign
            List<IDoor> doors = new List<IDoor> {new OpenDoor(),new OpenDoor()};
            Hallway hallway = new Hallway(doors);
            //act
            hallway.NumberOfOpenDoors().Should().Be(2);
            hallway.ChangeState(1);
            //assert
            hallway.NumberOfOpenDoors().Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldChangeStateOfDoors_WhenClosed()
        {
            //assign
            List<IDoor> doors = new List<IDoor> {new ClosedDoor(),new ClosedDoor(),new OpenDoor()};
            Hallway hallway = new Hallway(doors);
            //act
            hallway.NumberOfOpenDoors().Should().Be(1);
            hallway.ChangeState(1);
            //assert
            hallway.NumberOfOpenDoors().Should().Be(2);
        }
    }

    public class Hallway
    {
        private List<IDoor> _doors;

        public Hallway(List<IDoor> doors)
        {
            _doors = doors;
        }

        public int NumberOfOpenDoors()
        {
            return _doors.Count(door => door.IsOpen());
        }

        public void ChangeState(int numberOfWalks)
        {
            _doors = _doors.Select(door => door.ChangeState()).ToList();
        }
    }

    public class OpenDoor : IDoor
    {
        public bool IsOpen()
        {
            return true;
        }

        public IDoor ChangeState()
        {
            return new ClosedDoor();
        }
    }

    public class ClosedDoor : IDoor
    {
        public bool IsOpen()
        {
            return false;
        }

        public IDoor ChangeState()
        {
            return new OpenDoor();
        }
    }

    public interface IDoor
    {
        bool IsOpen();
        IDoor ChangeState();
    }
}