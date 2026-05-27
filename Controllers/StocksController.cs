using FalconSignals.Services.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace FalconSignals.Controllers;

[ApiController]
[Route("api/v1/stocks")]
public class StocksController : ControllerBase
{
    private readonly DailyTimeSeriesService _dailyTimeSeriesService;

    public StocksController(DailyTimeSeriesService dailyTimeSeriesService)
    {
        _dailyTimeSeriesService = dailyTimeSeriesService;
    }

    [HttpGet("{symbol}/daily")]
    public async Task<IActionResult> GetDaily(string symbol)
    {
        var result = await _dailyTimeSeriesService.GetDailyTimeSeries(symbol);
        return Ok(result);
    }
}