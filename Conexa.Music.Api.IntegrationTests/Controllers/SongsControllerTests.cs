using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Conexa.Music.Api.IntegrationTests.Controllers
{
    public class SongsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SongsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetSongsNoParameters_BadRequest()
        {
            var response = await _client.GetAsync("/api/songs");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetSongsByCity_Ok()
        {
            var response = await _client.GetAsync("/api/songs?city=goiania");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetSongsByCoordinates_Ok()
        {
            var response = await _client.GetAsync("/api/songs?lat=5&lon=5");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
