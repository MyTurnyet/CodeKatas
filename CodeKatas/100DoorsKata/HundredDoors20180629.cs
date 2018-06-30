using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas._100DoorsKata
{
    [TestClass]
    public class HundredDoors20180629
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldOpenDoorWhenClosed()
        {
            //assign
            Door door = new Door();
            //act
            door.ChangeState();

            //assert
            door.IsOpen().Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldCloseDoorWhenOpen()
        {
            //assign
            Door door = new Door(true);
            //act
            door.ChangeState();

            //assert
            door.IsOpen().Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldIterateDoors1Time()
        {
            //assign
            DoorMan doorMan = new DoorMan();
            //act
            doorMan.WalkDoors(1);
            //assert
            doorMan.OpenDoorCount().Should().Be(100);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldIterateDoors2Times()
        {
            //assign
            DoorMan doorMan = new DoorMan();
            //act
            doorMan.WalkDoors(2);
            //assert
            doorMan.OpenDoorCount().Should().Be(50);
        }

        private class DoorMan
        {
            private List<Door> _allDoors;

            public void WalkDoors(int iterations)
            {
                InitializeDoorList();
                for (int currentIteration = 1; currentIteration <= iterations; currentIteration++)
                {
                    for (int currentIndex = 0; currentIndex < 100; currentIndex += currentIteration)
                    {
                        _allDoors[currentIndex].ChangeState();
                    }
                }
            }

            private void InitializeDoorList()
            {
                _allDoors = new List<Door>();
                for (int currentDoor = 0; currentDoor < 100; currentDoor++) { _allDoors.Add(new Door()); }
            }
            public int OpenDoorCount() => _allDoors.Count(door => door.IsOpen());
        }

        private class Door
        {
            private bool _stateIsOpen;

            public Door() : this(false) { }
            public Door(bool stateIsOpen)
            {
                _stateIsOpen = stateIsOpen;
            }

            public void ChangeState() => _stateIsOpen = !_stateIsOpen;
            public bool IsOpen() => _stateIsOpen;
        }
    }
}
