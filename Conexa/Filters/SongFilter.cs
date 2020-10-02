using Conexa.WebApi.Core.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conexa.Music.Api.Filters
{
    public class SongFilter : FilterModelBase
    {
        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public string City { get; set; }

        public SongFilter() : base()
        {
            Limit = 10;
        }


        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}
