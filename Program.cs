using FalconSignals.Data;
using FalconSignals.Repositories;
using FalconSignals.Services.AlphaVantage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<AlphaVantageService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DailyTimeSeriesRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();