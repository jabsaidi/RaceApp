using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceApp.Classes;
using RaceApp.Endorsments;
using System.Collections.Generic;

namespace RaceApp.Test1
{
    [TestClass()]
    public class DriverTest
    {
        [TestMethod()]
        public void Endorsers()
        {
            List<Endorser> EndorsersList = new List<Endorser>();
            string name = "CGI";
            EndorsersList.Add(new Endorser(name));

            //Assert
            Assert.AreEqual(1, EndorsersList.Count);
        }

        [TestMethod()]
        public void AddsNewDriver()
        {
            Driver driver = new F1("jabir", "f1", 76);

            //Assert
            Assert.IsNotNull(driver);
        }

        [TestMethod()]
        public void AddsNewSegment()
        {
            Segment segment = new Segment("S turn", GroundType.sand);

            //Assert
            Assert.IsNotNull(segment);
        }

        [TestMethod()]
        public void SegmentTimeCalculator()
        {
            int time = 35;

            Driver driver = new F1("jabir", "f1", 76);
            driver.TimeSpentOnSegment.Add(time);

            //Assert
            Assert.AreEqual(1, driver.TimeSpentOnSegment.Count);
        }

        [TestMethod()]
        public void RaceTimeCalculator_totalIsCorrect()
        {
            Driver driver = new F1("jabir", "f1", 76);
            int time = 35;
            int time2 = 35;

            //Act
            List<int> TimeSpentOnSegment = new List<int>();
            TimeSpentOnSegment.Add(time);
            TimeSpentOnSegment.Add(time2);

            driver.RaceTimeCalculator(TimeSpentOnSegment);

            //Assert
            Assert.AreEqual(70, driver.TotalTime);
        }

        [TestMethod()]
        public void DriftControl_AddsNewSegmentToList()
        {
            Driver driver = new F1("jabir", "f1", 76);
            Segment segment = new Segment("S turn", GroundType.sand);

            driver.DrivenSegments.Add(segment);

            //Assert
            Assert.AreEqual(1, driver.DrivenSegments.Count);
        }

        [TestMethod()]
        public void AddPoints()
        {
            Driver driver = new F1("jabir", "f1", 76);
            int percentage = 10;
            driver.Performence = 80;

            driver.AddPoints(driver, percentage);

            Assert.AreEqual(90, driver.Performence);
        }

        [TestMethod()]
        public void RemovePoints()
        {
            Driver driver = new F1("jabir", "f1", 76);
            int percentage = 10;
            driver.Performence = 80;

            driver.RemovePoints(driver, percentage);

            Assert.AreEqual(70, driver.Performence);
        }

        [TestMethod()]
        public void AddPoints_PerformanceShouldNotBeOver100()
        {
            Driver driver = new F1("jabir", "f1", 76);
            int percentage = 40;
            driver.Performence = 80;

            driver.AddPoints(driver, percentage);

            Assert.AreEqual(100, driver.Performence);
        }

        [TestMethod()]
        public void RemovePoints_PerformanceShouldNotBeUnder0()
        {
            Driver driver = new F1("jabir", "f1", 76);
            int percentage = 40;
            driver.Performence = 20;

            driver.RemovePoints(driver, percentage);

            Assert.AreEqual(0, driver.Performence);
        }
    }
}
