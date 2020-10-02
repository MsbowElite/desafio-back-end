using Conexa.Music.Api.Filters;
using Conexa.Music.Application.Songs;
using Conexa.Music.Application.Songs.GetSongsByTemperatureOfCity;
using Conexa.Music.Application.Songs.GetSongsByTemperatureOfCoordinates;
using Conexa.WebApi.Core;
using Conexa.WebApi.Core.Paging;
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
        [ProducesResponseType(typeof(PagedCollectionResponse<SongDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] SongFilter filter)
        {
            try
            {
                var result = new PagedCollectionResponse<SongDto>();

                if (string.IsNullOrEmpty(filter.City))
                {
                    if (filter.Lat == null && filter.Lon == null)
                    {
                        return BadRequest("Please fill [lat] and [lon] or [city]");
                    }
                    result.Items = await QueryAsync(new GetSongsByTemperatureOfCoordinatesQuery(filter.Lat.Value, filter.Lon.Value, filter.Offset, filter.Limit));
                }
                else
                    result.Items = await QueryAsync(new GetSongsByTemperatureOfCityQuery(filter.City, filter.Offset, filter.Limit));

                //Get next page URL string  
                SongFilter nextFilter = filter.Clone() as SongFilter;
                nextFilter.Offset += filter.Limit;
                String nextUrl = result.Items.Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

                //Get previous page URL string  
                SongFilter previousFilter = filter.Clone() as SongFilter;
                previousFilter.Offset -= filter.Limit;
                String previousUrl = previousFilter.Offset <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

                result.NextPage = !String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
                result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
