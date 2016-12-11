using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core.Util
{
    public class RetryHelper
    {
        public static async Task<T> RetryOnExceptionAsync<T>(int times, TimeSpan deley, Func<Task<T>> operation) where T : class
        {
            if (times < 0) {
                throw new ArgumentOutOfRangeException(nameof(times));
            }
            T response  = null;
            var attemps = 0;
            while (attemps < times)
            { 
                try
                {
                    response = await operation();
                    return response;
                }
                catch (Exception)
                {
                    attemps++;
                    Task.Delay(deley).Wait();
                }
            }
            return response;
        }
    }
}



