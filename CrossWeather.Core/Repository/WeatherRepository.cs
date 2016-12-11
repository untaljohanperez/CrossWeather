using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CrossWeather.Core.Models;
using CrossWeather.Core.Util;

namespace CrossWeather.Core.Repository
{
    public class WeatherRepository
    {
        private string Url;
        public WeatherRepository(string city)
        {
            Url = ApiSetting.GetUrl(city);

        }

        public async Task<WeatherRoot> GetWeather()
        {
            WeatherRoot WeatherRoot = null;
            try
            {
                var HttpClient = new HttpClient();
                string Json = await RetryHelper.RetryOnExceptionAsync<string>(3, TimeSpan.FromSeconds(10), async () => {
                    return await HttpClient.GetStringAsync(Url);
                });
                HttpClient.Dispose();

                if (Json?.Length == 0)
                    throw new Exception();

                await Task.Run(() =>
                {
                    WeatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(Json);
                });
            }
            catch (Exception e)
            {
                throw e;
            }       
            return WeatherRoot;
        }
    }
}
