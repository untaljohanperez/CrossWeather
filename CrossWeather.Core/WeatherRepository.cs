using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrossWeather.Core
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
                var Json = await DoRequestWithIntents(HttpClient);
                HttpClient.Dispose();

                if (Json.Equals(string.Empty))
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

        private async Task<string> DoRequestWithIntents(HttpClient HttpClient)
        {
            var Json = string.Empty;
            var Intents = 5;
            while (Intents > 0)
            {
                try
                {
                    Json = await HttpClient.GetStringAsync(Url);
                    return Json;
                }
                catch (Exception)
                {
                    Intents--;
                }
            }
            return Json;
        }
    }
}
