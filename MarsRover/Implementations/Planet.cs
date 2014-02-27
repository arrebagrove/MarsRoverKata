using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Planet : IPlanet
    {

        public int Xsize { get; set; }

        public int Ysize { get; set; }

        public IEnumerable<IPosition> ObjectsOnMap { get; set; }
    }

}
