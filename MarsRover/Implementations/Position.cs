using MarsRover.Common;
using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Implementations
{
    public class Position : BasePosition, IPosition
    {
        public Position(int xCoordinate, int yCoordinate, string direction):base(xCoordinate, yCoordinate, direction)
        {

        }

        public Position(int xCoordinate, int yCoordinate, CompassDirection? direction):base(xCoordinate,yCoordinate,direction)
        {
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Xcoordinate, Ycoordinate, Direction.ToString()[0]);
        }
    }
}
