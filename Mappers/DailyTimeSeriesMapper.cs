using FalconSignals.Dtos.AlphaVantage;
using FalconSignals.Entities;

namespace FalconSignals.Mappers;

public static class DailyTimeSeriesMapper
{
    public static DailyTimeSeries ToEntity(AlphaVantageDailyDto dto, string symbol, DateTime date)
    {
        return new DailyTimeSeries
        {
            Symbol = symbol,
            Date = DateTime.SpecifyKind(date, DateTimeKind.Utc),
            Open = decimal.Parse(dto.Open),
            High = decimal.Parse(dto.High),
            Low = decimal.Parse(dto.Low),
            Close = decimal.Parse(dto.Close),
            Volume = long.Parse(dto.Volume)
            
        };
    }
}