using FalconSignals.Data;
using FalconSignals.Repositories;
using FalconSignals.Services.AlphaVantage;
using FalconSignals.Services.Stocks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<AlphaVantageService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DailyTimeSeriesRepository>();
builder.Services.AddScoped<DailyTimeSeriesService>();

var app = builder.Build();

app.MapControllers();

app.Run();