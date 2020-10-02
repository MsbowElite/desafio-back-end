using Conexa.Music.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Music.Application.Interfaces
{
    public interface ISongAppService : IDisposable
    {
        Task<IEnumerable<SongViewModel>> GetSongsByTemperatureOfCity(string city);

        Task<SongViewModel> GetSongsByCoordinates(int latitude, int longitude);
    }
}
