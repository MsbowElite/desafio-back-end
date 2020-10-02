using Conexa.Core.Configuration.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Conexa.Music.Application.Songs.GetSongsByTemperatureOfCity
{
    public class GetSongsByTemperatureOfCityQuery : QueryBase<IEnumerable<SongDto>>
    {
        [JsonProperty("city")]
        [Required]
        public string City { get; }

        public GetSongsByTemperatureOfCityQuery()
        {
        }

        [JsonConstructor]
        public GetSongsByTemperatureOfCityQuery(string city)
        {
            City = city;
        }
    }
}
