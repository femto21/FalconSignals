using System.Text.Json;
using FalconSignals.Dtos.AlphaVantage;
using FalconSignals.Mappers;
using FalconSignals.Repositories;
using FalconSignals.Services.AlphaVantage;

namespace FalconSignals.Services.Stocks;

public class DailyTimeSeriesService
{
    private readonly DailyTimeSeriesRepository _repository;
    private readonly AlphaVantageService _avService;

    public DailyTimeSeriesService(DailyTimeSeriesRepository repository, AlphaVantageService avService)
    {
        _repository = repository;
        _avService = avService;
    }

    public async Task<object> GetDailyTimeSeries(string symbol)
    {
        var data = await _repository.GetBySymbolAsync(symbol);

        if (data.Count > 0)
        {
            return data;
        }
        
        return await ImportDailyTimeSeries(symbol);
    }

    private async Task<List<Entities.DailyTimeSeries>> ImportDailyTimeSeries(string symbol)
    {
        var json = await _avService.GetDailyTimeSeries(symbol);

        var response = JsonSerializer.Deserialize<AlphaVantageDailyResponseDto>(json);

        if (response?.TimeSeriesDaily == null)
        {
            return new List<Entities.DailyTimeSeries>();
        }

        var entities = response
            .TimeSeriesDaily
            .Select(x => 
                DailyTimeSeriesMapper.ToEntity(x.Value, symbol, DateTime.Parse(x.Key))).ToList();

        await _repository.AddRangeAsync(entities);

        return entities;
    }
}