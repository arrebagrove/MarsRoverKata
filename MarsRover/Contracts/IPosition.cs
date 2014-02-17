using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Contracts
{
    public interface IPosition
    {
        int Xcoordinate { get; }
        int Ycoordinate { get; }
        CompassDirection Direction { get; }
    }
}
