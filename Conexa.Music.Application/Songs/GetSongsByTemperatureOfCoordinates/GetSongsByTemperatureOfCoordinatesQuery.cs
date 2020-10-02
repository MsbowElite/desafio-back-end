using Conexa.Core.Configuration.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Conexa.Music.Application.Songs.GetSongsByTemperatureOfCoordinates
{
    public class GetSongsByTemperatureOfCoordinatesQuery : QueryBase<IEnumerable<SongDto>>
    {
        [JsonProperty("lat")]
        [Required]
        public double Latitude { get; }

        [JsonProperty("lon")]
        [Required]
        public double Longitude { get; }

        public GetSongsByTemperatureOfCoordinatesQuery()
        {
        }

        [JsonConstructor]
        public GetSongsByTemperatureOfCoordinatesQuery(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
