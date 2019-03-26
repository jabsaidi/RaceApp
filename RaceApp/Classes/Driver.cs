using RaceApp.Endorsments;
using RaceApp.Helpers;
using System;
using System.Collections.Generic;

namespace RaceApp.Classes
{
    public abstract class Driver
    {
        public int Speed { get; set; }
        public string Car { get; set; }
        public string Name { get; set; }
        public int TotalTime { get; set; }
        public int Performence { get; set; }
        RandomGenerator random = new RandomGenerator();
        List<Endorser> EndorsersList = new List<Endorser>();
        public List<int> TimeSpentOnSegment = new List<int>();
        public List<Segment> DrivenSegments = new List<Segment>();

        public Driver(string name, string car, int performence, int speed = 180)
        {
            Car = car;
            Name = name;
            Speed = speed;
            Performence = performence;
            int totalEndorsers = random.Generate(1, 6);
            EndorsersList = Endrosers(totalEndorsers);
        }

        public List<Endorser> Endrosers(int totalEndorsers)
        {
            int i = 0;
            while (i < totalEndorsers)
            {
                string name = random.EndorserName();
                EndorsersList.Add(new Endorser(name));
                i++;
            }
            return EndorsersList;
        }

        public abstract void PointsCalculator(Driver driver, Segment segment);

        public virtual void SunConditions(Driver driver, Segment segment)
        {
            throw new NotImplementedException();
        }

        public virtual void RainConditions(Driver driver, Segment segment)
        {
            throw new NotImplementedException();
        }

        public virtual void WindConditions(Driver driver, Segment segment)
        {
            throw new NotImplementedException();
        }

        public virtual void DriftControl(Driver driver, Segment segment, int chances = 2)
        {
            int odds = random.Generate(1, chances);
            if (odds == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{driver.Name} lost control and will have to drive through the {segment.Ground} {segment.TrackSegment} again.");
                Console.ForegroundColor = ConsoleColor.Gray;

                driver.DrivenSegments.Add(segment);
                SegmentTimeCalculator(driver.Speed, segment, driver);
            }
        }

        public virtual void SpeedCalculator(Driver driver, Segment segment, Weather weather)
        {
            throw new NotImplementedException();
        }

        public void RemovePoints(Driver driver, int percentage)
        {
            if (IsInRange(driver, percentage))
            {
                driver.Performence -= percentage;
            }
            else
            {
                driver.Performence = 0;
            }
        }

        public void AddPoints(Driver driver, int percentage)
        {
            if (IsInRange(driver, percentage))
            {
                driver.Performence += percentage;
            }
            else
            {
                driver.Performence = 100;
            }
        }

        public bool IsInRange(Driver driver, int percentage)
        {
            if (driver.Performence - percentage < 0)
            {
                return false;
            }
            else if (driver.Performence + percentage > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SegmentTimeCalculator(int speed, Segment segment, Driver driver)
        {
            int time;
            int distance = segment.Length;

            time = (distance * 60) / speed;
            driver.TimeSpentOnSegment.Add(time);
        }

        public void RaceTimeCalculator(List<int> TimeSpentOnSegment)
        {
            int totalTime = 0;
            foreach (var time in TimeSpentOnSegment)
            {
                totalTime += time;
            }
            TotalTime = totalTime;
        }

        public bool IsSand(GroundType ground)
        {
            return ground == GroundType.sand;
        }

        public bool IsCurve(string trackSegment)
        {
            return trackSegment == "curve";
        }

        public bool IsSTurn(string trackSegment)
        {
            return trackSegment == "S turn";
        }

        public bool IsLine(string trackSegment)
        {
            return trackSegment == "straight line";
        }

        public bool IsSun(Weather weather)
        {
            return weather == Weather.Sun;
        }

        public bool IsRain(Weather weather)
        {
            return weather == Weather.Rain;
        }

        public bool IsWind(Weather weather)
        {
            return weather == Weather.Wind;
        }
    }
}
