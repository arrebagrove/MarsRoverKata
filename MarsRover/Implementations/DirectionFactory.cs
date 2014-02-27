using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Implementations
{
    public class DirectionFactory
    {
        public CompassDirection? Get(char firstLetter)
       {
            switch (firstLetter)
            {
                case 'N':
                case 'n':
                    return CompassDirection.North;
                case 'S':
                case 's':
                    return CompassDirection.South;
                case 'E':
                case 'e':
                    return CompassDirection.East;
                case 'W':
                case 'w':
                    return CompassDirection.West;
                default:
                    return null;
            }
        }
    }
}
