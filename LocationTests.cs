using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Tracker.models.location;

namespace Tracker.Tests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void Update_North_Calculated()
        {
            var location = new Location(50.681728, 18.956220, 0.0);
             location.update(50.713822, 8.970458, 0.0);

            Assert.IsInstanceOfType(location.totalMovement, typeof(double));
              Assert.AreEqual(703.58, location.totalMovement);
          
        }
        [TestMethod]
        public void Update_South_Calculated()
        {
            var location = new Location(-50.681728, -18.956220, 0.0);
            location.update(-50.713822,-8.970458, 0.0);

            Assert.IsInstanceOfType(location.totalMovement, typeof(double));
            Assert.AreEqual(703.58, location.totalMovement);

        }
        [TestMethod]
        public void Update_AltitudeChanges_Calculated()
        {
            var location = new Location(-50.681728, -18.956220, -100000.0);
            location.update(-50.713822, -8.970458, 0.0);

            Assert.IsInstanceOfType(location.totalMovement, typeof(double));
            Assert.AreEqual(710.65, location.totalMovement);

        }
        
    }
}
