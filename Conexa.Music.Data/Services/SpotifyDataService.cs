using Conexa.Music.Domain.Interfaces;
using Conexa.Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Conexa.Music.Data.Services
{
    public class SpotifyDataService : ISpotifyDataService
    {
        private readonly HttpClient _httpClient;

        public SpotifyDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Item>> GetTracksByGenre(string genre, int offset, int limit)
        {
            UriBuilder builder = new UriBuilder(_httpClient.BaseAddress + $"/search?q=genre:{genre}&type=track&offset={offset}&limit={limit}");

            var spotifyResult = await JsonSerializer.DeserializeAsync<SpotifyResult>
                (await _httpClient.GetStreamAsync(builder.Uri), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });

            return spotifyResult.tracks.items;
        }
    }
}
