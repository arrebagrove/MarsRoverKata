using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Contracts
{
    public interface IPlanet
    {
        int Xsize { get; set; }
        int Ysize { get; set; }
        IEnumerable<IPosition> ObjectsOnMap { get; set; }
    }
}
