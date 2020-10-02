using Conexa.Music.Domain.Interfaces;
using Conexa.Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Conexa.Music.Data.Services
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly HttpClient _httpClient;

        public WeatherDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<double> GetTemperatureByCityName(string cityName)
        {
            UriBuilder builder = new UriBuilder(_httpClient.BaseAddress + $"&q={cityName}");

            var weatherResult = await JsonSerializer.DeserializeAsync<WeatherResult>
                (await _httpClient.GetStreamAsync(builder.Uri), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });

            if (weatherResult.Main != null)
                return weatherResult.Main.Temp;
            else
                return 0;
        }

        public async Task<double> GetTemperatureByCoordinates(double latitude, double longitude, byte numberOfCities = 1)
        {
            UriBuilder builder = new UriBuilder(_httpClient.BaseAddress + $"&lat={latitude}&lon={longitude}&cnt={numberOfCities}");

            var weatherResult = await JsonSerializer.DeserializeAsync<WeatherResult>
                (await _httpClient.GetStreamAsync(builder.Uri), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });

            if (weatherResult.Main != null)
                return weatherResult.Main.Temp;
            else
                return 0;
        }
    }
}
