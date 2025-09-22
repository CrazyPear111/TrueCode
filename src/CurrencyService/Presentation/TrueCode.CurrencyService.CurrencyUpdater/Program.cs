using TrueCode.CurrencyService.Configuration;
using TrueCode.CurrencyService.CurrencyUpdater;
using TrueCode.CurrencyService.Data;
using TrueCode.CurrencyService.RateClient;
using TrueCode.CurrencyService.UseCases;

var builder = Host.CreateApplicationBuilder(args);

var appSettings = builder.GetAppSettings();

builder.Services.AddHostedService<Worker>();
builder.Services
    .AddUseCases()
    .AddDataServices(appSettings)
    .AddRateClient();

var host = builder.Build();
host.Run();
