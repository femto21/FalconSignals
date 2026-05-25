namespace FalconSignals.Services.AlphaVantage;

public class AlphaVantageService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public AlphaVantageService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string> GetDailyTimeSeries(string symbol)
    {
        var apiKey = _config["AlphaVantage:ApiKey"];

        var url =
            $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}";

        return await _httpClient.GetStringAsync(url);
    }
}