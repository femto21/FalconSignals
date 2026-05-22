using System.Text.Json.Serialization;

namespace FalconSignals.Dtos.AlphaVantage;

public record AlphaVantageDailyDto(
    [property: JsonPropertyName("1. open")] decimal Open,

    [property: JsonPropertyName("2. high")] decimal High,

    [property: JsonPropertyName("3. low")] decimal Low,

    [property: JsonPropertyName("4. close")] decimal Close,

    [property: JsonPropertyName("5. volume")] long Volume
);