using TrueCode.CurrencyService.Api.Services;
using TrueCode.CurrencyService.Configuration;
using TrueCode.CurrencyService.Data;
using TrueCode.CurrencyService.UseCases;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.GetAppSettings();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services
    .AddDataServices()
    .AddUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CurrencyService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
