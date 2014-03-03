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
        private IPlanet _planet;
        private bool _useBitWise = false;

        private bool _collision = false;
        public bool Collision
        {
            get 
            {
                return _collision;
            }
        }

        public RobotController(IPosition position)
        {
            _currentPosition = position;
            _planet = new Planets().Jupiter;
        }

        public RobotController(IPosition position, IPlanet planet)
        {
            _currentPosition = position;
            _planet = planet;
        }

        public IPosition Move(ICommand command)
        {
            _command = command;

            Drive();

            _currentPosition = _newPosition;

            DetectCollisions();
            return _currentPosition;
        }

        private void DetectCollisions()
        {
            if (_planet != null)
            {
                IEnumerable<IPosition> collisions = _planet.ObjectsOnMap.Select(o => o).Where(o => o.ToString().Equals(_currentPosition.ToString()));
                _collision = collisions.Any();
            }
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
                    SetNewPositionForFacingEastOrWest();
                    break;
                case CompassDirection.West:
                    _useBitWise = true;
                    SetNewPositionForFacingEastOrWest();
                    break;
                default:
                    _newPosition = _currentPosition;
                    break;
            }
        }

        private void SetNewPositionForFacingNorthOrSouth()
        {
            _newPosition = new Position(_currentPosition.Xcoordinate, DriveCalculation(_currentPosition.Ycoordinate, _planet.Ysize), _currentPosition.Direction);
        }

        private void SetNewPositionForFacingEastOrWest()
        {
            _newPosition = new Position(DriveCalculation(_currentPosition.Xcoordinate, _planet.Xsize), _currentPosition.Ycoordinate, _currentPosition.Direction);
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

            _currentPosition = _newPosition;

            DetectCollisions();
            return _currentPosition;
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
