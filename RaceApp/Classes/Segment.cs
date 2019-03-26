using RaceApp.Helpers;
using System;

namespace RaceApp.Classes
{
    public class Segment
    {
        public string TrackSegment { get; set; }
        public int Length{ get; set; }
        public GroundType Ground { get; set; }
        RandomGenerator random = new RandomGenerator();

        public Segment(string segment, GroundType groundType)
        {
            int length = random.Generate(25, 100);
            TrackSegment = segment;
            Ground = groundType;
            Length = length;
        }

        public void RaceLogs(Segment segment, Driver driver)
        {
            Console.WriteLine($"\n{segment.TrackSegment}...");
            if (segment.TrackSegment == "S turn")
                driver.DriftControl(driver, segment);
        }
    }
}
