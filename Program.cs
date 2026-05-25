using FalconSignals.Services.AlphaVantage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<AlphaVantageService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();