using FalconSignals.Data;
using FalconSignals.Entities;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task AddRangeAsync(List<DailyTimeSeries> list)
    {   
        await _context.DailyTimeSeries.AddRangeAsync(list);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DailyTimeSeries>> GetBySymbolAsync(string symbol)
    {
        return await _context.DailyTimeSeries
            .Where(x => x.Symbol == symbol)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }
}