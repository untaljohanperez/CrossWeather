using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CrossWeather.Core;

namespace CrossWeather.Droid
{
    [Activity(Label = "CrossWeather.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.search);
            EditText city = FindViewById<EditText>(Resource.Id.editCity);
            TextView lat = FindViewById<TextView>(Resource.Id.lat);
            TextView lon = FindViewById<TextView>(Resource.Id.lon);
            TextView temp = FindViewById<TextView>(Resource.Id.temp);
            TextView country = FindViewById<TextView>(Resource.Id.country);
            button.Click += async delegate 
            {
                try
                {
                    var WeatherRepository = new WeatherRepository(city.Text);
                    var Weather = await WeatherRepository.GetWeather();
                    if(Weather?.Id == 0)
                    {
                        Toast.MakeText(this, "Invalid city. Try again", ToastLength.Short).Show();
                        return;
                    }
                    lon.Text = $"Longitude: {Weather.Coord.Lon}";
                    lat.Text = $"Latitude: {Weather.Coord.Lat}";
                    temp.Text = $"Temperature: {Weather.Main.Temp}";
                    country.Text = $"Country: {Weather.Sys.Country}";
                }
                catch (Exception)
                {
                    city.Text = string.Empty;
                    Toast.MakeText(this, "There was a error. Try again", ToastLength.Short).Show();
                }
            };
        }
    }
}

