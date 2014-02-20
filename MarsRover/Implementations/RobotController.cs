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
        private IPosition _newPosition;
        private ICommand _command;

        public RobotController(IPosition position)
        {
            _currentPosition = position;
        }

        public IPosition Move(ICommand command)
        {
            _command = command;

            //is degrees
            if (IsDegrees())
            {
                RotateRobot();
            }
            else
            {
                Move();
            }
            //is fwd or backwrds
            return _newPosition;
        }

        private void RotateRobot()
        {

        }

        private void Move()
        {
            int x = _currentPosition.Xcoordinate + _command.CommandValue;
            _newPosition = new Position(x, _currentPosition.Ycoordinate, _currentPosition.Direction);
        }

        private bool IsDegrees()
        {
            if (_command.CommandValue != -1 || _command.CommandValue != 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
