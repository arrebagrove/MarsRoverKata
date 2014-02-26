using MarsRover.Common;
using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class RobotQueueCommandRunner : IRobotQueueCommandRunner
    {
        private IRobotController _robotController;

        public RobotQueueCommandRunner(IRobotController controller)
        {
            _robotController = controller;
        }
        public IEnumerable<IPosition> Run(string queueOfCommands)
        {
            foreach (char command in queueOfCommands)
            {
                ICommand commandToRun = new CommandFactory().Get(command);

                yield return _robotController.Move(commandToRun);
            }
        }
    }
}
