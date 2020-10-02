using Conexa.Music.Domain.Queries.Songs.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Queries.Songs
{
    public class SongGetByTemperatureOfCityCommandQuery : SongCommandQuery
    {
        public SongGetByTemperatureOfCityCommandQuery(string city)
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new SongGetByTemperatureOfCityQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
