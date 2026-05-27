using System.Text.Json.Serialization;

namespace FalconSignals.Dtos.AlphaVantage;

public record AlphaVantageDailyDto(
    [property: JsonPropertyName("1. open")] string Open,

    [property: JsonPropertyName("2. high")] string High,

    [property: JsonPropertyName("3. low")] string Low,

    [property: JsonPropertyName("4. close")] string Close,

    [property: JsonPropertyName("5. volume")] string Volume
);