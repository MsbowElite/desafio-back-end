using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Application.Helpers
{
    public static class SongGenreProvider
    {
        public static string GetGenreByTemperature(double temperature)
        {
            if (temperature > (int)TemperatureRanges.LowerPartyTemperature && temperature <= (int)TemperatureRanges.HigherTemperature)
                return SongGenres.Party;

            if (temperature > (int)TemperatureRanges.LowerPopTemperature && temperature <= (int)TemperatureRanges.HigherPopTemperature)
                return SongGenres.Pop;

            if (temperature > (int)TemperatureRanges.LowerRockTemperature && temperature <= (int)TemperatureRanges.HigherRockTemperature)
                return SongGenres.Rock;

            if (temperature > (int)TemperatureRanges.LowerTemperature && temperature <= (int)TemperatureRanges.HigherClassicTemperature)
                return SongGenres.Classic;

            throw new Exception("Invalid temperature");
        }
    }
}
