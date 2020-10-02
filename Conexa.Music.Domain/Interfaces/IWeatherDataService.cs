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

        Task<double> GetTemperatureByCoordinates(double latitude, double longitude, byte numberOfCities = 1);
    }
}
