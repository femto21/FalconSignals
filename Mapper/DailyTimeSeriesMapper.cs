using FalconSignals.Dtos.AlphaVantage;
using FalconSignals.Entities;

namespace FalconSignals.Mapper;

public class DailyTimeSeriesMapper
{
    public DailyTimeSeries ToEntity(AlphaVantageDailyDto dto, string symbol)
    {
        return new DailyTimeSeries
        {
            Symbol = symbol,
            Open = dto.Open,
            High = dto.High,
            Low = dto.Low,
            Close = dto.Close,
            Volume = dto.Volume
            
        };
    }
}