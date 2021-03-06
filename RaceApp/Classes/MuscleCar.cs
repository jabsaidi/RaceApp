﻿using RaceApp.Helpers;

namespace RaceApp.Classes
{
    public class MuscleCar : Driver
    {
        public MuscleCar(string name, string car, int performence, int speed = 150) : base(name, car, performence, speed)
        {
        }

        public override void DriftControl(Driver driver, Segment segment, int chances)
        {
            base.DriftControl(driver, segment, 8);
        }

        public override void PointsCalculator(Driver driver, Segment segment)
        {
            if (IsCurve(segment.TrackSegment))
            {
                //ajoute 20%
                RemovePoints(driver, 10);
            }
            else if (IsLine(segment.TrackSegment))
            {
                //ajoute 20%
                AddPoints(driver, 20);
            }
            else if (IsSTurn(segment.TrackSegment))
            {
                //ajoute 20%
                RemovePoints(driver, 10);
            }
        }

        public override void SpeedCalculator(Driver driver, Segment segment, Weather weather)
        {
            string WhoCares = $"I don't car that the weather gives me {weather}. I'm a freaking {driver.Car}!";

            int currSpeed = driver.Speed;
            int tempSpeed;

            if (IsCurve(segment.TrackSegment))
            {
                tempSpeed = currSpeed - RandomGenerator.Generate(10, 20);
                SegmentTimeCalculator(tempSpeed, segment, driver);
            }
            else if (IsLine(segment.TrackSegment))
            {
                tempSpeed = currSpeed + RandomGenerator.Generate(20, 60);
                SegmentTimeCalculator(tempSpeed, segment, driver);
            }
            else if (IsSTurn(segment.TrackSegment))
            {
                tempSpeed = currSpeed - RandomGenerator.Generate(10, 30);
                SegmentTimeCalculator(tempSpeed, segment, driver);
            }
        }
    }
}

