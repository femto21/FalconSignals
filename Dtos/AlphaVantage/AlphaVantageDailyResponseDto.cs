using System.Text.Json.Serialization;

namespace FalconSignals.Dtos.AlphaVantage;

public class AlphaVantageDailyResponseDto
{
    [JsonPropertyName("Time Series (Daily)")]
    public Dictionary<string, AlphaVantageDailyDto> TimeSeriesDaily { get; set; }
}