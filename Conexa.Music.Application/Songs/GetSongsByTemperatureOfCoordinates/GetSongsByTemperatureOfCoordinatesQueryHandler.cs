using AutoMapper;
using Conexa.Music.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Conexa.Music.Application.Helpers;
using MediatR;

namespace Conexa.Music.Application.Songs.GetSongsByTemperatureOfCoordinates
{
    public class GetSongsByTemperatureOfCoordinatesQueryHandler :
        IRequestHandler<GetSongsByTemperatureOfCoordinatesQuery, IEnumerable<SongDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISpotifyDataService _spotifyDataService;
        private readonly IWeatherDataService _weatherDataService;

        public GetSongsByTemperatureOfCoordinatesQueryHandler(IMapper mapper,
          ISpotifyDataService spotifyDataService,
          IWeatherDataService weatherDataService)
        {
            _mapper = mapper;
            _spotifyDataService = spotifyDataService;
            _weatherDataService = weatherDataService;
        }

        public async Task<IEnumerable<SongDto>> Handle(GetSongsByTemperatureOfCoordinatesQuery request, CancellationToken cancellationToken)
        {
            var temperature = await _weatherDataService.GetTemperatureByCoordinates(request.Latitude, request.Longitude);

            var genre = SongGenreProvider.GetGenreByTemperature(temperature);

            var spotifyItens = await _spotifyDataService.GetTracksByGenre(genre);

            return _mapper.Map<IEnumerable<SongDto>>(spotifyItens);
        }
    }
}
