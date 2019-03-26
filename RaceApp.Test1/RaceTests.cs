using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceApp.Classes;
using System.Collections.Generic;

namespace RaceApp.Test1
{
    [TestClass()]
    public class RaceTest
    {
        [TestMethod()]
        public void Participants_AddingNewDriver()
        {
            var drivers = new List<Driver>();
            var f1Driver = new F1("cobaille", "toyota", 1);

            //Act
            drivers.Add(f1Driver);

            //assert
            Assert.IsNotNull(f1Driver);
            Assert.AreEqual(1, drivers.Count);
        }

        [TestMethod()]
        public void Participants_AddingDriverWithRandom()
        {
            var drivers = new List<Driver>();
            Driver driver;
            //Act
            driver = new MuscleCar("cobaille", "Muscle Car", 20);
            drivers.Add(driver);

            //assert
            Assert.IsTrue(driver is MuscleCar);
            Assert.IsFalse(driver is F1);
        }

        [TestMethod()]
        public void WinnerIs()
        {
            var drivers = new List<Driver>();

            Driver f1 = new F1("cobaille", "F1", 20);
            Driver rally = new Rally("cobaille", "F1", 20);
            Race race = new Race();
            //Act
            f1.TotalTime = 180;
            rally.TotalTime = 179;
            drivers.Add(f1);
            drivers.Add(rally);

            Driver winner = race.WinnerIs(drivers);

            //Assert
            Assert.IsTrue(winner == rally);
        }
    }
}
