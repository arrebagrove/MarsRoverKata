﻿using MarsRover.Common;
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
            if (IsTurnCommand())
            {
                TurnRobot();
            }
            else
            {
                Drive();
            }

            return _newPosition;
        }

        private void TurnRobot()
        {
            if (_currentPosition.Direction.HasValue)
            {
                bool isLeftCommand = _command.CommandValue == -2;
                bool isRightCommand = _command.CommandValue == 2;

                int rotateValue = isLeftCommand ? -1 : isRightCommand ? 1 : 0;

                int newDirectionValue = (int)_currentPosition.Direction.Value + rotateValue;

                newDirectionValue = newDirectionValue < 0 ? 3 : newDirectionValue;

                CompassDirection newDirection = (CompassDirection)newDirectionValue;
                _newPosition = new Position(_currentPosition.Xcoordinate, _currentPosition.Ycoordinate, newDirection);
            }
        }

        private void Drive()
        {
            int x = _currentPosition.Xcoordinate + _command.CommandValue;
            _newPosition = new Position(x, _currentPosition.Ycoordinate, _currentPosition.Direction);
        }

        private bool IsTurnCommand()
        {
            if (_command.CommandValue == -1 || _command.CommandValue == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
