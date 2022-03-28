using System.Text.Json.Serialization;

namespace WeatherMaster.Models
{
    public class WeatherResultMain
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float MinimumTemperature { get; set; }

        [JsonPropertyName("temp_max")]
        public float MaximumTemperature { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public float Humidity { get; set; }
    }
}
