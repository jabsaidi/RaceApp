using RaceApp.Classes;
using System;

namespace RaceApp.Helpers
{
    public class RandomGenerator
    {
        public Random random = new Random();
        public int Min { get; set; }
        public int Max { get; set; }

        public RandomGenerator()
        {
        }

        public int Generate(int min, int max)
        {
            return random.Next(min, max);
        }

        public string NameGenerator()
        {
            string name;
            int nameOptions = Generate(1, 12);
            if (nameOptions == 1)
            {
                name = "Travis";
            }
            else if (nameOptions == 2)
            {
                name = "Aiden";
            }
            else if (nameOptions == 3)
            {
                name = "Jabir";
            }
            else if (nameOptions == 4)
            {
                name = "Mike";
            }
            else if (nameOptions == 5)
            {
                name = "JS";
            }
            else if (nameOptions == 6)
            {
                name = "Oli";
            }
            else if (nameOptions == 7)
            {
                name = "Ivaylo";
            }
            else if (nameOptions == 8)
            {
                name = "Dominic";
            }
            else if (nameOptions == 9)
            {
                name = "Dany";
            }
            else if (nameOptions == 10)
            {
                name = "Nathan";
            }
            else
            {
                name = "Jim";
            }
            return name;
        }

        public string EndorserName()
        {
            int maxEndorsers = Generate(1, 6);
            string name;

            if (maxEndorsers == 1)
            {
                name = "Avon";
            }
            else if (maxEndorsers == 2)
            {
                name = "CGI";
            }
            else if (maxEndorsers == 3)
            {
                name = "Google";
            }
            else if (maxEndorsers == 4)
            {
                name = "Cactus Jack";
            }
            else
            {
                name = "NASA";
            }
            return name;
        }

        public Weather WeatherOdds()
        {
            int weatherOptions = Generate(1, 4);
            var currWeather = Weather.Sun;

            if (weatherOptions == 1)
            {
                currWeather = Weather.Sun;
            }

            else if (weatherOptions == 2)
            {
                currWeather = Weather.Sun;
            }
            else if (weatherOptions == 3)
            {
                currWeather = Weather.Sun;
            }
            return currWeather;
        } 
    }
}
