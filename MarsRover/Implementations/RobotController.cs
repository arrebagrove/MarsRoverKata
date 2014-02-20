using MarsRover.Common;
using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class RobotController : IRobotController
    {
        private IPosition _currentPosition;

        public RobotController(IPosition position)
        {
            _currentPosition = position;
        }

        public IPosition Move(ICommand command)
        {
            return new Position(100, 00, CompassDirection.South);
        }
    }
}
