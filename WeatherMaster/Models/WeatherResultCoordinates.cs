using System.Text.Json.Serialization;

namespace WeatherMaster.Models
{
    public class WeatherResultCoordinates
    {
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }

        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
    }
}
