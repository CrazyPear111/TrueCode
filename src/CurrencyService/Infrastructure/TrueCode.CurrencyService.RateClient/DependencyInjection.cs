using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.RateClient;

public static class DependencyInjection
{
    public static IServiceCollection AddRateClient(this IServiceCollection services)
    {
        services.AddScoped<ICbrClient, CbrClient>();
        return services;
    }
}
