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
    
    
}