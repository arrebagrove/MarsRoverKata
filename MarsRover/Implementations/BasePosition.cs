using MarsRover.Common;
using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Implementations
{
    public abstract class BasePosition : IPosition
    {
        public int Xcoordinate
        {
            get;
        }

        public int Ycoordinate
        {
            get;
        }

        public CompassDirection CompassDirection
        {
            get;
        }

        public abstract override string ToString(); 
    }
}
