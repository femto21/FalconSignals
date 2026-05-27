namespace FalconSignals.Entities;

public class DailyTimeSeries
{
    public int Id { get; set; }
    public required string Symbol { get; set; }
    public DateTime Date { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public long Volume { get; set; }
}