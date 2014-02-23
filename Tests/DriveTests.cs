using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Contracts;
using MarsRover.Implementations;
using NUnit.Framework;
using MarsRover.Common;

namespace Tests
{
    [TestFixture]
    public class DriveTests
    {
        [TestCase(3, 1, 'W', "4,1,W")]
        [TestCase(0,0,'N', "0,1,N")]
        public void ForwardByOne(int startingXCoordinate, int startingYCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);

            IPosition robotStartPosition = new Position(startingXCoordinate, startingYCoordinate, compassDirection);

            ICommand robotCommand = new Forward();

            IRobotController robotController = new RobotController(robotStartPosition);

            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }

        [TestCase(0, 0, 'N', "0,99,N")]
        public void ReverseByOne(int startingXCoordinate, int startingYCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);

            IPosition robotStartPosition = new Position(startingXCoordinate, startingYCoordinate, compassDirection);

            ICommand robotCommand = new Reverse();

            IRobotController robotController = new RobotController(robotStartPosition);

            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }
    }
}
