using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class PositionTest
    {
        [TestCase(0,0,"N")]
        public void PositionToStringFormat(int xCoordinate, int yCoordinate, string faceDirection)
        {
            CompassDirection direction = DirectionFactory().Get(faceDirection);
            IPosition position = new Position(xCoordinate, yCoordinate, faceDirection);
        }
    }
}
