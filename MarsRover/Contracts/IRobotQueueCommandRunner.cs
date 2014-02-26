using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Contracts
{
    public interface IRobotQueueCommandRunner
    {
        IEnumerable<IPosition> Run(string queueOfCommands);
    }
}
