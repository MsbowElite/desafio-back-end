using AutoMapper;
using Conexa.Core.Communication.Mediator;
using Conexa.Music.Application.Interfaces;
using Conexa.Music.Application.ViewModels;
using Conexa.Music.Domain.Interfaces;
using Conexa.Music.Domain.Queries.Songs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Conexa.Music.Application.Helpers;

namespace Conexa.Music.Application.Services
{
    public class SongAppService : ISongAppService
    {
        private readonly IMapper _mapper;
        private readonly ISpotifyDataService _spotifyDataService;
        private readonly IWeatherDataService _weatherDataService;

        public SongAppService(IMapper mapper,
                  ISpotifyDataService spotifyDataService,
                  IWeatherDataService weatherDataService)
        {
            _mapper = mapper;
            _spotifyDataService = spotifyDataService;
            _weatherDataService = weatherDataService;
        }

        public async Task<IEnumerable<SongViewModel>> GetSongsByTemperatureOfCity(string city)
        {
            var temperature = await _weatherDataService.GetTemperatureByCityName(city);

            var genre = SelectSongGenreByTemeprature(temperature);

            var spotifyItens = await _spotifyDataService.GetTracksByGenre(genre);

            return _mapper.Map<IEnumerable<SongViewModel>>(spotifyItens);
        }

        public async Task<IEnumerable<SongViewModel>> GetSongsByCoordinates(double latitude, double longitude)
        {
            var temperature = await _weatherDataService.GetTemperatureByCoordinates(latitude, longitude);

            var genre = SelectSongGenreByTemeprature(temperature);

            var spotifyItens = await _spotifyDataService.GetTracksByGenre(genre);

            return _mapper.Map<IEnumerable<SongViewModel>>(spotifyItens);
        }

        private string SelectSongGenreByTemeprature(double temperature)
        {
            if (temperature > (int)TemperatureRanges.LowerPartyTemperature && temperature <= (int)TemperatureRanges.HigherTemperature)
                return SongGenres.Party;

            if (temperature > (int)TemperatureRanges.LowerPopTemperature && temperature <= (int)TemperatureRanges.HigherPopTemperature)
                return SongGenres.Pop;

            if (temperature > (int)TemperatureRanges.LowerRockTemperature && temperature <= (int)TemperatureRanges.HigherRockTemperature)
                return SongGenres.Rock;

            if (temperature > (int)TemperatureRanges.LowerTemperature && temperature <= (int)TemperatureRanges.HigherClassicTemperature)
                return SongGenres.Classic;

            throw new Exception("Invalid temperature");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
