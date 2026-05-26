using FalconSignals.Services.AlphaVantage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<AlphaVantageService>();

var app = builder.Build();

app.MapControllers();

app.Run();