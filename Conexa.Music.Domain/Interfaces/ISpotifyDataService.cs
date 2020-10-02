using Conexa.Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Music.Domain.Interfaces
{
    public interface ISpotifyDataService
    {
        Task<List<Item>> GetTracksByGenre(string genre);
    }
}
