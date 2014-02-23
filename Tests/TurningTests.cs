using MarsRover.Common;
using MarsRover.Contracts;
using MarsRover.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TurningTests
    {
        [TestCase(0, 0, 'N', "0,0,E")]
        public void MoveRight(int xCoordinate, int yCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);

            IPosition robotStartPosition = new Position(xCoordinate, yCoordinate, compassDirection);

            IRobotController robotController = new RobotController(robotStartPosition);

            IRotate robotCommand = new RotateRight();

            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }

        [TestCase(0, 0, 'N', "0,0,W")]
        public void MoveLeft(int xCoordinate, int yCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);

            IPosition robotStartPosition = new Position(xCoordinate, yCoordinate, compassDirection);

            IRobotController robotController = new RobotController(robotStartPosition);

            IRotate robotCommand = new RotateLeft();

            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }
    }
}
