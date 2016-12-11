using CrossWeather.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossWeather.Core.Models;
using CrossWeather.Core.Repository;

namespace CrossWeather.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherRepositoryGetWeatherTest().Wait();
            Console.ReadLine();
        }
        public static async Task<WeatherRoot> WeatherRepositoryGetWeatherTest()
        {
            Console.WriteLine("Doing Request to Weather API...");
            var WeatherRepository = new WeatherRepository("Medellin");
            var Weather = await WeatherRepository.GetWeather();
            Console.WriteLine(Weather.Sys.Country);
            Console.WriteLine(Weather.Name);
            Console.WriteLine(Weather.Main.Temp);
            Console.WriteLine("Request completed");
            return Weather;
        }
    }
}
