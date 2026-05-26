using FalconSignals.Data;
using FalconSignals.Entities;

namespace FalconSignals.Repositories;

public class DailyTimeSeriesRepository
{
    private readonly AppDbContext _context;

    public DailyTimeSeriesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DailyTimeSeries dailyTimeSeries)
    {
        _context.DailyTimeSeries.Add(dailyTimeSeries);
        await _context.SaveChangesAsync();
    }
}