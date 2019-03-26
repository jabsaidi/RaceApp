using RaceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RaceApp.Classes
{
    public class RaceTrack
    {
        public List<Segment> _segments = new List<Segment>();
        RandomGenerator _random = new RandomGenerator();
        public Weather Weather { get; private set; }
        public RaceTrack()
        {
            Weather = _random.WeatherOdds();
        }

        public List<Segment> RaceSegments()
        {
            int segmentAmount = _random.Generate(2, 21);
            for (int i = 0; i < segmentAmount; i++)
            {
                int groundtype = _random.Generate(1, 3);
                int turnOrNot = _random.Generate(1, 4);
                if (groundtype == 1)
                {
                    if (turnOrNot == 1)
                    {
                        _segments.Add(new Segment("curve", GroundType.sand));
                    }
                    else if (turnOrNot == 2)
                    {
                        _segments.Add(new Segment("straight line", GroundType.sand));
                    }
                    else
                    {
                        _segments.Add(new Segment("S turn", GroundType.sand));
                    }
                }
                else
                {
                    if (turnOrNot == 1)
                    {
                        _segments.Add(new Segment("curve", GroundType.asphalt));
                    }
                    else if (turnOrNot == 2)
                    {
                        _segments.Add(new Segment("straight line", GroundType.asphalt));
                    }
                    else
                    {
                        _segments.Add(new Segment("S turn", GroundType.asphalt));
                    }
                }
            }
            Console.WriteLine($"\n\n\nThe racetrack has {segmentAmount} different segments...\n");
            Wait(2000);
            Console.WriteLine($"\n\n                                                        Ready?");
            Wait(2000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"                                                          3");
            Wait(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"                                                          2");
            Wait(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"                                                          1");
            Wait(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                                         GO!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return _segments;
        }

        private void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
