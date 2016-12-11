using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWeather.Core.Models
{
    public class WeatherRoot
    {
        public String Base {get; set;}
        public Cloud Clouds { get; set; }
        public int Cod { get; set; }
        public Coord Coord { get; set; }
        public long Dt { get; set; }
        public int Id { get; set; }
        public Main Main { get; set; }
        public String Name { get; set; }
        public Sys Sys { get; set; }
        public int Visibility { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public Wind Wind { get; set; } 
    }
}
