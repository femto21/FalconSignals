using FalconSignals.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconSignals.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<DailyTimeSeries> DailyTimeSeries { get; set; }
}