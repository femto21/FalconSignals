namespace FalconSignals.Services.StocksService;

public class StocksService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public StocksService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string> getDailyTimeSeries(string symbol)
    {
        
    }
    
}