using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core
{
    public class WeatherRepositoryTest
    {
        public static void Main(String[] args)
        {
           test().Wait();

        }

        public static async Task<WeatherRoot> test() {
            var WeatherRepository = new WeatherRepository("Medellin");
            var Weather = await WeatherRepository.GetWeather();
            return Weather;
        }
    }
}
