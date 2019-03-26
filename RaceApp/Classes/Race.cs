using RaceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RaceApp.Classes
{
    public class Race
    {
        private List<Driver> drivers = new List<Driver>();
        RaceTrack track = new RaceTrack();
        RandomGenerator random = new RandomGenerator();

        public void Participants()
        {
            Console.WriteLine("                         How many drivers?                            *Has to be at least 2");
            int racers = Convert.ToInt32(Console.ReadLine());
            if (racers < 2)
                NotEnough();

            for (int i = 0; i < racers; i++)
            {
                int type = random.Generate(1, 5);
                if (type == 1)
                {
                    drivers.Add(new F1(random.NameGenerator(), "F1", random.Generate(20, 51)));
                }
                else if (type == 2)
                {
                    drivers.Add(new Nascar(random.NameGenerator(), "Nascar", random.Generate(20, 51)));
                }
                else if (type == 3)
                {
                    drivers.Add(new Rally(random.NameGenerator(), "Rally", random.Generate(20, 51)));
                }
                else
                {
                    drivers.Add(new MuscleCar(random.NameGenerator(), "Muscle Car", random.Generate(20, 51)));
                }
            }
            Wait(1000);
            Console.WriteLine("\nThe drivers are:\n");
            Wait(1000);
            drivers.ForEach(i => Console.Write($"{i.Name} ({i.Car})\t|\t"));
            Wait(2000);
            List<Segment> segments = track.RaceSegments();
            PointConditions(drivers, segments);
        }

        private void NotEnough()
        {
            Console.WriteLine("Has to be AT LEAST 2 drivers!\n");
            Wait(1000);
            Participants();
        }

        private void PointConditions(List<Driver> drivers, List<Segment> segments)
        {
            foreach (var driver in drivers)
            {
                Console.WriteLine($"\n\n\t\t\t\t\t\t{driver.Name}'s ({driver.Car}) Race Report:");

                foreach (var segment in segments)
                {
                    Weather weather = track.Weather;
                    driver.DrivenSegments.Add(segment);
                    driver.PointsCalculator(driver, segment);
                    driver.SpeedCalculator(driver, segment, weather);
                    segment.RaceLogs(segment, driver);
                    Wait(1500);
                }
            }
            Chrono(drivers);
        }

        private void Chrono(List<Driver> drivers)
        {
            foreach (var driver in drivers)
            {
                driver.RaceTimeCalculator(driver.TimeSpentOnSegment);
            }
            WinnerIs(drivers);
        }

        public Driver WinnerIs(List<Driver> drivers)
        {
            var winner = drivers[0];
            for (int i = 0; i < drivers.Count - 1; i++)
            {
                if (drivers[i].TotalTime > drivers[i + 1].TotalTime)
                {
                    winner = drivers[i + 1];
                }
            }
            Console.WriteLine($"\n\n\n{winner.Name} wins!! He took {winner.TotalTime} seconds to finish the race.");
            Ranking(drivers);
            return winner;
        }

        private void Ranking(List<Driver> drivers)
        {
            List<Driver> Ranking = new List<Driver>();
            foreach (var driver in drivers)
            {
                Ranking.Add(driver);
            }
            DisplayRanking(Ranking);
        }

        private void DisplayRanking(List<Driver> Ranking)
        {
            var rank = Ranking.OrderBy(driver => driver.TotalTime);

            Console.WriteLine("Here is the ranking:\n");
            int j = 1;
            foreach (var driver in rank)
            {
                Console.WriteLine($"{j} : {driver.Name} - Time : {driver.TotalTime}");
                Console.WriteLine("__________________________");
                j++;
            }
        }

        private void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
