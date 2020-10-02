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

        public int Limit { get; set; }

        public int Offset { get; set; }

        public GetSongsByTemperatureOfCityQuery()
        {
        }

        [JsonConstructor]
        public GetSongsByTemperatureOfCityQuery(string city, int offset, int limit)
        {
            City = city;
            Limit = limit;
            Offset = offset;
        }
    }
}
