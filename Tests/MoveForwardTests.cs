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
    public class MoveForwardTests
    {
        [TestCase(0,0,'N', "1,0,N")]
        public void MoveForward(int xCoordinate, int yCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);

            IPosition robotStartPosition = new Position(xCoordinate, yCoordinate, compassDirection);

            ICommand robotCommand = new Forward();

            IRobotController robotController = new RobotController(robotStartPosition);


            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }
    }
}
