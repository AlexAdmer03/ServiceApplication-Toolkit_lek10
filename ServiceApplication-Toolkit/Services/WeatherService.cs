using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceApplication_Toolkit.Services
{
    public class WeatherService
    {
        private readonly string _url = "";

        private readonly Timer _timer;
        private readonly HttpClient _http;

        public string? CurrentWeatherCondition { get; private set; }
        public string? CurrentTemperature { get; private set; }
        public event Action? WeatherUpdated;

        public WeatherService(HttpClient http)
        {
            _http = http;

            Task.Run(SetCurrentWeatherAsync);

            _timer = new Timer(60000 * 15);
            _timer.Elapsed += async(s, e) SetCurrentWeatherAsync();
            _timer.Start();
        }

        private async Task SetCurrentWeatherAsync()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(await _http.GetStringAsync(_url));
                CurrentTemperature = (data!.main.temp - 273.15).ToString("#");
                CurrentWeatherCondition = GetWeatherConditionIcon(data!.weather[0].description.ToString());
            }
            catch
            {
                CurrentTemperature = "--";
                CurrentWeatherCondition = GetWeatherConditionIcon("--");
            }
            WeatherUpdated?.Invoke();
        }

        private string GetWeatherConditionIcon(string value)
        {

        }
    }
}
