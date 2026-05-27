using FalconSignals.Repositories;

namespace FalconSignals.Services.AlphaVantage;

public class AlphaVantageService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly DailyTimeSeriesRepository _repository;

    public AlphaVantageService(HttpClient httpClient, IConfiguration config, DailyTimeSeriesRepository repository)
    {
        _httpClient = httpClient;
        _config = config;
        _repository = repository;
    }

    public async Task<string> GetDailyTimeSeries(string symbol)
    {
        var apiKey = _config["AlphaVantage:ApiKey"];

        var url =
            $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}";

        var response = await _httpClient.GetStringAsync(url);
        
        return response ;
    }
}