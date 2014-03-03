using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Planets
    {
        public Planet Jupiter
        {
            get
            {
                return new Planet
                {
                    Xsize = 100,
                    Ysize = 100,
                    ObjectsOnMap = new List<IPosition>()
                };
            }
        }
    }
}
