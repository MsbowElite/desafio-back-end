using Conexa.Music.Application.Interfaces;
using Conexa.Music.Application.ViewModels;
using Conexa.WebApi.Core;
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
    public class SongsController : ApiController
    {
        private readonly ISongAppService _songAppService;

        public SongsController(ISongAppService songAppService)
        {
            _songAppService = songAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SongViewModel>), StatusCodes.Status200OK)]
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
                    return Ok(await _songAppService.GetSongsByCoordinates(lat.Value, lon.Value));
                }
                else
                    return Ok(await _songAppService.GetSongsByTemperatureOfCity(city));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
