using MarsRover.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class MoveForwardTests
    {
        [TestCase(0,0,"N", "1,0,N")]
        public void MoveForward(int xCoordinate, int yCoordinate, string faceDirection, string expected)
        {
            IPosition robotStartPosition = Position(x, y, faceDirection);

            ICommand robotCommand = new Forward();

            IRobotController robotController = new RobotController(robotStartPosition);

            
            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.That(robotEndPosition.ToString(), Is.EqualTo(expected));
        }
    }
}
