using CrossWeather.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            test().Wait();

        }
        public static async Task<WeatherRoot> test()
        {
            var WeatherRepository = new WeatherRepository("Medellin");
            var Weather = await WeatherRepository.GetWeather();
            return Weather;
        }
    }
}
