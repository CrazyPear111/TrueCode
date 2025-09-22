using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.RateClient;
using TrueCode.CurrencyService.UseCases;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.CurrencyUpdater;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
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
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
