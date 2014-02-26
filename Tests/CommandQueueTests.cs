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
    public class CommandQueueTests
    {
        [TestCase(0, 0, 'N', "FRLRFB", "0,1,E")]
        public void FollowEachCommandInCommandQueue(int startXcoordinate, int startYCoordiate, char startFacingDirectionFirstLetter, string queueOfCommands, string expectedEndPosition)
        {
            CompassDirection? startFacingDirection = new DirectionFactory().Get(startFacingDirectionFirstLetter);
            
            IPosition startPosition = new Position(startXcoordinate, startYCoordiate, startFacingDirection);

            IRobotController controller = new RobotController(startPosition);

            IRobotQueueCommandRunner queueOfCommandsRunner = new RobotQueueCommandRunner(controller);

            IEnumerable<IPosition> robotPath = queueOfCommandsRunner.Run(queueOfCommands);

            Assert.That(robotPath.LastOrDefault().ToString(), Is.EqualTo(expectedEndPosition));

        }

        [TestCase('F', "Forward")]
        [TestCase('B', "Reverse")]
        [TestCase('L', "RotateLeft")]
        [TestCase('R', "RotateRight")]
        public void GetCommandFromFactory(char commandType, string expectedCommand)
        {
            ICommand command = new CommandFactory().Get(commandType);

            string commandName = command.GetType().Name;

            Assert.That(commandName, Is.EqualTo(expectedCommand));
        }
    }
}
