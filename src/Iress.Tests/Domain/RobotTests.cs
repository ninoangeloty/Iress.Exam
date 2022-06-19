using Iress.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Tests.Domain
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot()
        {
            var robot = new Robot(5, 5);

            Assert.AreNotEqual(Guid.Empty, robot.Id);
            Assert.AreEqual(Direction.NONE, robot.Direction);
        }

        [TestMethod]
        public void Place_ShouldUpdatePositionAndDirectionWhenValid()
        {
            var robot = new Robot(5, 5);

            robot.Place(3, 2, Direction.WEST);

            Assert.AreEqual(new Coordinate(3, 2), robot.Position);
            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [TestMethod]
        public void Place_ShouldNotUpdatePositionAndDirectionWhenInvalid()
        {
            var robot = new Robot(5, 5);

            robot.Place(5, 5, Direction.WEST);

            Assert.AreEqual(null, robot.Position);
            Assert.AreEqual(Direction.NONE, robot.Direction);
        }

        [TestMethod]
        public void Move_UpdatePositionWhenFacingNorth()
        {
            var robot = new Robot(5, 5);
            robot.Place(0, 0, Direction.NORTH);
            robot.Move();

            Assert.AreEqual(1, robot.Position.Value.X);
        }

        [TestMethod]
        public void Move_UpdatePositionWhenFacingSouth()
        {
            var robot = new Robot(5, 5);
            robot.Place(1, 0, Direction.SOUTH);
            robot.Move();

            Assert.AreEqual(0, robot.Position.Value.X);
        }

        [TestMethod]
        public void Move_UpdatePositionWhenFacingEast()
        {
            var robot = new Robot(5, 5);
            robot.Place(0, 0, Direction.EAST);
            robot.Move();

            Assert.AreEqual(1, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_UpdatePositionWhenFacingWest()
        {
            var robot = new Robot(5, 5);
            robot.Place(0, 1, Direction.WEST);
            robot.Move();

            Assert.AreEqual(0, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_IgnoreWhenOutOfBoundsAndFacingNorth()
        {
            var robot = new Robot(3, 3);
            robot.Place(2, 2, Direction.NORTH);
            robot.Move();

            Assert.AreEqual(2, robot.Position.Value.X);
            Assert.AreEqual(2, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_IgnoreWhenOutOfBoundsAndFacingEast()
        {
            var robot = new Robot(3, 3);
            robot.Place(2, 2, Direction.EAST);
            robot.Move();

            Assert.AreEqual(2, robot.Position.Value.X);
            Assert.AreEqual(2, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_IgnoreWhenOutOfBoundsAndFacingSouth()
        {
            var robot = new Robot(3, 3);
            robot.Place(0, 0, Direction.SOUTH);
            robot.Move();

            Assert.AreEqual(0, robot.Position.Value.X);
            Assert.AreEqual(0, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_IgnoreWhenOutOfBoundsAndFacingWest()
        {
            var robot = new Robot(3, 3);
            robot.Place(0, 0, Direction.SOUTH);
            robot.Move();

            Assert.AreEqual(0, robot.Position.Value.X);
            Assert.AreEqual(0, robot.Position.Value.Y);
        }

        [TestMethod]
        public void Move_IgnoreWhenPositionIsNotSet()
        {
            var robot = new Robot(5, 5);

            robot.Move();

            Assert.AreEqual(null, robot.Position);
        }

        [TestMethod]
        public void Left_UpdateDirectionWhenFacingNorth()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.NORTH);
            robot.Left();

            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [TestMethod]
        public void Left_UpdateDirectionWhenFacingEast()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.EAST);
            robot.Left();

            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [TestMethod]
        public void Left_UpdateDirectionWhenFacingSouth()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.SOUTH);
            robot.Left();

            Assert.AreEqual(Direction.EAST, robot.Direction);
        }

        [TestMethod]
        public void Left_UpdateDirectionWhenFacingWest()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.WEST);
            robot.Left();

            Assert.AreEqual(Direction.SOUTH, robot.Direction);
        }

        [TestMethod]
        public void Left_IgnoreWhenPositionIsNotSet()
        {
            var robot = new Robot(5, 5);

            robot.Left();

            Assert.AreEqual(null, robot.Position);
        }

        [TestMethod]
        public void Right_UpdateDirectionWhenFacingNorth()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.NORTH);
            robot.Right();

            Assert.AreEqual(Direction.EAST, robot.Direction);
        }

        [TestMethod]
        public void Right_UpdateDirectionWhenFacingEast()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.EAST);
            robot.Right();

            Assert.AreEqual(Direction.SOUTH, robot.Direction);
        }

        [TestMethod]
        public void Right_UpdateDirectionWhenFacingSouth()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.SOUTH);
            robot.Right();

            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [TestMethod]
        public void Right_UpdateDirectionWhenFacingWest()
        {
            var robot = new Robot(1, 1);
            robot.Place(0, 0, Direction.WEST);
            robot.Right();

            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [TestMethod]
        public void Right_IgnoreWhenPositionIsNotSet()
        {
            var robot = new Robot(5, 5);

            robot.Right();

            Assert.AreEqual(null, robot.Position);
        }
    }
}
