using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceApp.Classes;

namespace RaceApp.Test1
{
    [TestClass()]
    public class F1Test
    {
        [TestMethod()]
        public void PointsCalculator_RemovePointsIfSand()
        {
            Driver driver = new F1("cobaille", "Muscle Car", 20);
            Segment segment = new Segment("S turn", GroundType.sand);

            driver.Performence = 50;
            driver.PointsCalculator(driver, segment);

            Assert.AreEqual(30, driver.Performence);
        }

        [TestMethod()]
        public void PointsCalculator_AddPointsIfAsphalt()
        {
            Driver driver = new F1("cobaille", "Muscle Car", 20);
            Segment segment = new Segment("S turn", GroundType.asphalt);

            driver.Performence = 50;
            driver.PointsCalculator(driver, segment);

            Assert.AreEqual(80, driver.Performence);
        }

        [TestMethod()]
        public void NewF1()
        {
            Driver driver = new F1("cobaille", "Muscle Car", 20);

            Assert.IsNotNull(driver);
            Assert.IsTrue(driver is F1);
        }

        [TestMethod()]
        public void SpeedCalculator_AddsSpeedInList()
        {
            Driver driver = new F1("cobaille", "Muscle Car", 20);
            Segment segment = new Segment("straight line", GroundType.asphalt);
            Weather weather = Weather.Sun;

            driver.SpeedCalculator(driver, segment, weather);

            Assert.AreEqual(1, driver.TimeSpentOnSegment.Count);
        }
    }
}
