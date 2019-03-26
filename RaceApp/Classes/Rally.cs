using RaceApp.Helpers;
using System;

namespace RaceApp.Classes
{
    public class Rally : Driver
    {
        RandomGenerator random = new RandomGenerator();

        public Rally(string name, string car, int performence, int speed = 180) : base(name, car, performence, speed)
        {
        }

        public override void DriftControl(Driver driver, Segment segment, int chances)
        {
            base.DriftControl(driver, segment, 4);
        }

        public override void PointsCalculator(Driver driver, Segment segment)
        {
            if (IsSand(segment.Ground))
            {
                //ajoute 50%
                AddPoints(driver, 50);
            }
            else
            {
                if (IsCurve(segment.TrackSegment))
                {
                    //ajoute 20%
                    AddPoints(driver, 20);
                }
                else if (IsLine(segment.TrackSegment))
                {
                    //retire 10%
                    RemovePoints(driver, 10);
                }
                else if (IsSTurn(segment.TrackSegment))
                {
                    //ajoute 20%
                    AddPoints(driver, 20);
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
            RallyBasicWeatherConditions(driver, segment, 0);
        }

        public override void RainConditions(Driver driver, Segment segment)
        {
            RallyBasicWeatherConditions(driver, segment, 10);
        }

        public override void WindConditions(Driver driver, Segment segment)
        {
            RallyBasicWeatherConditions(driver, segment, 20);
        }


        private void RallyBasicWeatherConditions(Driver driver, Segment segment, int speedReduction)
        {
            int currSpeed = driver.Speed - speedReduction;
            int tempSpeed;
            if (IsSand(segment.Ground))
            {
                currSpeed -= random.Generate(50, 70);

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
