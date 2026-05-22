namespace FalconSignals.Dtos;

public record DailyTimeSeriesDto(
    decimal open,
    decimal high,
    decimal low,
    decimal close,
    long volume
);