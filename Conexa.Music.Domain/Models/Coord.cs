using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Models
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
