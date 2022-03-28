using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherMaster.Models
{
    public class WeatherResult
    {
        [JsonPropertyName("coord")]
        public WeatherResultCoordinates Coordinates { get; set; }

        [JsonPropertyName("weather")]
        public IEnumerable<WeatherResultWeather> Weather { get; set; }

        [JsonPropertyName("base")]
        public string StationBase { get; set; }

        [JsonPropertyName("main")]
        public WeatherResultMain Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}