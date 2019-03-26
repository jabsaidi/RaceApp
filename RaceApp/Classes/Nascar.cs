using RaceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceApp.Classes
{
    public class Nascar : Driver
    {
        RandomGenerator random = new RandomGenerator();
        public Nascar(string name, string car, int performence, int speed = 215) : base(name, car, performence, speed)
        {
        }

        public override void DriftControl(Driver driver, Segment segment, int chances)
        {
            base.DriftControl(driver, segment, 5);
        }

        public override void PointsCalculator(Driver driver, Segment segment)
        {
            if (IsSand(segment.Ground))
            {
                //retire 20%
                RemovePoints(driver, 20);
            }
            else
            {
                if (IsCurve(segment.TrackSegment))
                {
                    //retire 20%
                    RemovePoints(driver, 20);
                }
                else if (IsLine(segment.TrackSegment))
                {
                    //ajoute 60%
                    AddPoints(driver, 60);
                }
                else if (IsSTurn(segment.TrackSegment))
                {
                    //ajoute 20%
                    AddPoints(driver, 70);
                }
            }
        }

        public override void SpeedCalculator(Driver driver, Segment segment, Weather weather)
        {
            if (IsSun(weather))
            {
                SunConditions(driver, segment);
            }
            else if (IsRain(weather))
            {
                RainConditions(driver, segment);
            }
            else if (IsWind(weather))
            {
                WindConditions(driver, segment);
            }
        }

        public override void SunConditions(Driver driver, Segment segment)
        {
            NascarBasicWeatherConditions(driver, segment, 0);
        }

        public override void RainConditions(Driver driver, Segment segment)
        {
            NascarBasicWeatherConditions(driver, segment, 20);
        }

        public override void WindConditions(Driver driver, Segment segment)
        {
            NascarBasicWeatherConditions(driver, segment, 10);
        }

        private void NascarBasicWeatherConditions(Driver driver, Segment segment, int speedRecution)
        {
            int currSpeed = driver.Speed - speedRecution;
            int tempSpeed;
            if (IsSand(segment.Ground))
            {
                currSpeed -= random.Generate(60, 80);

                if (IsCurve(segment.TrackSegment))
                {
                    tempSpeed = currSpeed - random.Generate(10, 20);
                    SegmentTimeCalculator(tempSpeed, segment, driver);
                }
                else if (IsLine(segment.TrackSegment))
                {
                    SegmentTimeCalculator(currSpeed, segment, driver);
                }
                else if (IsSTurn(segment.TrackSegment))
                {
                    tempSpeed = currSpeed - random.Generate(10, 30);
                    SegmentTimeCalculator(tempSpeed, segment, driver);
                }
            }
            else
            {
                if (IsCurve(segment.TrackSegment))
                {
                    tempSpeed = currSpeed - random.Generate(10, 20);
                    SegmentTimeCalculator(tempSpeed, segment, driver);
                }
                else if (IsLine(segment.TrackSegment))
                {
                    tempSpeed = currSpeed + random.Generate(10, 50);
                    SegmentTimeCalculator(tempSpeed, segment, driver);
                }
                else if (IsSTurn(segment.TrackSegment))
                {
                    tempSpeed = currSpeed - random.Generate(100, 120);
                    SegmentTimeCalculator(tempSpeed, segment, driver);
                }
            }
        }
    }
}
