using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
