using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.Configuration;
using TrueCode.CurrencyService.RateClient;
using TrueCode.CurrencyService.UseCases;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.CurrencyUpdater;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly AppSettings _appSettings;

    public Worker(
        ILogger<Worker> logger, 
        IServiceProvider serviceProvider,
        AppSettings appSettings)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _appSettings = appSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            using var scope = _serviceProvider.CreateScope();
            var updateCurrenciesUseCase = scope.ServiceProvider.GetRequiredService<UpdateCurrenciesUseCase>();

            await updateCurrenciesUseCase.Invoke();
            await Task.Delay(TimeSpan.FromMinutes(_appSettings.WorkInterval), stoppingToken);
        }
    }
}
