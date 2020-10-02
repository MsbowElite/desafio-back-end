using Conexa.Music.Application.Songs;
using Conexa.Music.Application.Songs.GetSongsByTemperatureOfCity;
using Conexa.Music.Application.Songs.GetSongsByTemperatureOfCoordinates;
using Conexa.WebApi.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conexa.Music.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class SongsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SongsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SongDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery]string city, [FromQuery]double? lat, [FromQuery]double? lon)
        {
            try
            {
                if (string.IsNullOrEmpty(city))
                {
                    if (lat == null && lon == null)
                    {
                        return BadRequest("Please fill [lat] and [lon] or [city]");
                    }
                    return Ok(await QueryAsync(new GetSongsByTemperatureOfCoordinatesQuery(lat.Value, lon.Value)));
                }
                else
                    return Ok(await QueryAsync(new GetSongsByTemperatureOfCityQuery(city)));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
