using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Contracts
{
    public interface IRobotController
    {
        IPosition Move(ICommand command);
    }
}
