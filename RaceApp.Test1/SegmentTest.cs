using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceApp.Test1
{
    [TestClass()]
    public class SegmentTest
    {
        [TestMethod()]
        public void LengthProvider()
        {
            int _length = 50;
            Segment segment = new Segment("Curve", GroundType.asphalt);

            var length = segment.LengthProvider(_length);

            Assert.AreEqual(50, length);
        }
    }
}