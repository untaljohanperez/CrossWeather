using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core
{
    public class ApiSetting
    {
        public static string GetUrl(String city)
        {
            var ApiKey = "52f9dfc8129e47f246d3f79cd0ea4423";
            return $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={ApiKey}";
        }
    }
}
