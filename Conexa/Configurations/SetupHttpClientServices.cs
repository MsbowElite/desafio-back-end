using Conexa.Core.Spotify;
using Conexa.Core.Weather;
using Conexa.Music.Data.Services;
using Conexa.Music.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Conexa.Music.Api.Configurations
{
    public static class SetupHttpClientServices
    {
        public static void HttpClientServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var spotifySettingsSection = configuration.GetSection("SpotifySettings");
            services.Configure<SpotifySettings>(spotifySettingsSection);
            var spotifySettings = spotifySettingsSection.Get<SpotifySettings>();

            var weatherSettingsSection = configuration.GetSection("WeatherSettings");
            services.Configure<WeatherSettings>(weatherSettingsSection);
            var weatherSettings = weatherSettingsSection.Get<WeatherSettings>();

            services.AddHttpClient<ISpotifyDataService, SpotifyDataService>(client =>
            {
                client.BaseAddress = new Uri("https://api.spotify.com/v1");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetSpotifyAccessToken(spotifySettings.Id, spotifySettings.Secret));
            });

            services.AddHttpClient<IWeatherDataService, WeatherDataService>(client =>
            {
                client.BaseAddress = new Uri($"https://api.openweathermap.org/data/2.5/weather?appid={weatherSettings.Key}&units={weatherSettings.Units}");
            });
        }

        public static string GetSpotifyAccessToken(string id, string secret)
        {
            string url5 = "https://accounts.spotify.com/api/token";

            //request to get the access token
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", id, secret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

            return JsonSerializer.Deserialize<SpotifyRequestToken>(json).access_token;
        }
    }
}
