using Conexa.Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Music.Domain.Interfaces
{
    public interface IWeatherDataService
    {
        Task<double> GetTemperatureByCityName(string cityName);

        Task<WeatherResult> GetByCoordinates(int latitude, int longitude, byte numberOfCities);
    }
}
