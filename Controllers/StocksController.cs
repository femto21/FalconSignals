using FalconSignals.Services.AlphaVantage;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FalconSignals.Controllers;

[ApiController]
[Route("api/v1/stocks")]
public class StocksController : ControllerBase
{
    private readonly AlphaVantageService _alphaVantageService;

    public StocksController(AlphaVantageService alphaVantageService)
    {
        _alphaVantageService = alphaVantageService;
    }

    [HttpGet("{symbol}/daily")]
    public async Task<IActionResult> GetDaily(string symbol)
    {
        var result = await _alphaVantageService.GetDailyTimeSeries(symbol);
        return Ok(result);
    }
    
}