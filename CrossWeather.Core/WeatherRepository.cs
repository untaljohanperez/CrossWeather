using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core
{
    public class WeatherRepository
    {
        private string url;
        public WeatherRepository(string city)
        {
            url = ApiSetting.GetUrl(city);

        }

        public async Task<WeatherRoot> GetWeather()
        {
            WeatherRoot WeatherRoot = null;
            try
            {
                using (var HttpClient = new HttpClient())
                {
                    var json = await HttpClient.GetStringAsync(url);
                    await Task.Run(() =>
                    {
                        WeatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(json);
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return WeatherRoot;
        }
    }
}
