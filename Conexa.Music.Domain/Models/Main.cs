using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }
}
