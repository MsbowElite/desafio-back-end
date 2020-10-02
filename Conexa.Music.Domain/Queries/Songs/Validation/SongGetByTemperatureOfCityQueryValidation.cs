using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Queries.Songs.Validation
{
    public class SongGetByTemperatureOfCityQueryValidation : SongQueryValidation<SongGetByTemperatureOfCityCommandQuery>
    {
        public SongGetByTemperatureOfCityQueryValidation()
        {
            ValidateCity();
        }
    }
}
