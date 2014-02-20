using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Implementations;
using MarsRover.Common;
using MarsRover.Contracts;

namespace Tests
{
    [TestFixture]
    public class PositionTest
    {
        [TestCase(0, 4, 'E', "0,4,E")]
        [TestCase(1, 1, 'E', "1,1,E")]
        [TestCase(0, 2, 'S', "0,2,S")]
        [TestCase(0,0,'N', "0,0,N")]
        public void PositionToStringFormat(int xCoordinate, int yCoordinate, char faceDirection, string expected)
        {
            CompassDirection? direction = new DirectionFactory().Get(faceDirection);

            IPosition position = new Position(xCoordinate, yCoordinate, direction);


            Assert.That(position.ToString(), Is.EqualTo(expected));
        }
    }
}
