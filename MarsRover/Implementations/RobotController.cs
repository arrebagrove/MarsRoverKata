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
        private int _xSize = 100;
        private int _ySize = 100;
        private bool _useBitWise = false;

        public RobotController(IPosition position)
        {
            _currentPosition = position;
        }

        public IPosition Move(ICommand command)
        {
            _command = command;

            Drive();

            return _newPosition;
        }

        private void Drive()
        {
            switch (_currentPosition.Direction)
            {
                case CompassDirection.North:
                    SetNewPositionForFacingNorthOrSouth();
                    break;
                case CompassDirection.South:
                    _useBitWise = true;
                    SetNewPositionForFacingNorthOrSouth();
                    break;
                case CompassDirection.East:
                    _useBitWise = true;
                    SetNewPositionForFacingEastOrWest();
                    break;
                case CompassDirection.West:
                    SetNewPositionForFacingEastOrWest();
                    break;
                default:
                    _newPosition = _currentPosition;
                    break;
            }
        }

        private void SetNewPositionForFacingNorthOrSouth()
        {
            _newPosition = new Position(_currentPosition.Xcoordinate, DriveCalculation(_currentPosition.Ycoordinate, _ySize), _currentPosition.Direction);
        }

        private void SetNewPositionForFacingEastOrWest()
        {
            _newPosition = new Position(DriveCalculation(_currentPosition.Xcoordinate, _xSize), _currentPosition.Ycoordinate, _currentPosition.Direction);
        }

        private int DriveCalculation(int valueToChange, int circumference)
        {
            int commandValue = _command.CommandValue;
            valueToChange += _useBitWise ? ~commandValue + 1 : commandValue;

            if (valueToChange < 0)
            {
                valueToChange = circumference - 1;
            }
            else if (valueToChange > circumference - 1)
            {
                valueToChange = 0;
            }

            _useBitWise = false;
            return valueToChange;
        }

        public IPosition Move(IRotate _rotateCommand)
        {
            _command = (ICommand)_rotateCommand;
            RotateRobot();
            return _newPosition;
        }

        private void RotateRobot()
        {
            if (_currentPosition.Direction.HasValue)
            {
                int newDirectionValue = (int)_currentPosition.Direction.Value + _command.CommandValue;

                newDirectionValue = RotateRobotWithNewDirectionValue(newDirectionValue);
            }
        }

        private int RotateRobotWithNewDirectionValue(int newDirectionValue)
        {
            newDirectionValue = newDirectionValue < 0 ? 3 : newDirectionValue > 3 ? 0 : newDirectionValue;

            CompassDirection newDirection = (CompassDirection)newDirectionValue;
            _newPosition = new Position(_currentPosition.Xcoordinate, _currentPosition.Ycoordinate, newDirection);
            return newDirectionValue;
        }

    }
}
