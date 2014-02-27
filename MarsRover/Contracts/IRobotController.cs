using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Contracts
{
    public interface IRobotController
    {
        bool Collision { get; }
        IPosition Move(ICommand command);
        IPosition Move(IRotate rotateCommand);
    }
}
