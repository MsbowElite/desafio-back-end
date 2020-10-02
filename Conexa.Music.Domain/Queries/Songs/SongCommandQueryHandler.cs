using Conexa.Core.Messages;
using Conexa.Music.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conexa.Music.Domain.Queries.Songs
{
    public class SongCommandQueryHandler : CommandHandler,
        IRequestHandler<SongGetByTemperatureOfCityCommandQuery, ValidationResult>
    {
        private readonly IWeatherDataService _weatherDataService;

        public SongCommandQueryHandler(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        public async Task<ValidationResult> Handle(SongGetByTemperatureOfCityCommandQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var temperature = await _weatherDataService.GetTemperatureByCityName(request.City);

            return null;
        }

        public void Dispose()
        {
        }
    }
}
