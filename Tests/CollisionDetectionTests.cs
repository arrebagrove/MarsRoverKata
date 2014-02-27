using MarsRover.Common;
using MarsRover.Contracts;
using MarsRover.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class CollisionDetectionTests
    {
        [TestCase(0,1)]
        public void CollisionAtCoordinates(int expectedXcoordinate, int expectedYcoordinate)
        {
            List<IPosition> objectsOnMap = new List<IPosition>();

            objectsOnMap.Add(new Position(expectedXcoordinate, expectedYcoordinate, CompassDirection.North));

            IPlanet mars = new Planet {
                Xsize =  40, 
                Ysize = 50, 
                ObjectsOnMap = objectsOnMap
            };

            IPosition startPosition = new Position(0,0,CompassDirection.North);

            IRobotController controller = new RobotController(startPosition, mars);

            IPosition endPosition = controller.Move(new Forward());

            Assert.True(controller.Collision);
            Assert.That(endPosition.ToString(), Is.EqualTo(objectsOnMap.FirstOrDefault().ToString()));
        }
    }
}
