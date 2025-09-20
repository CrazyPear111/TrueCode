using Microsoft.Extensions.DependencyInjection;

namespace TrueCode.Gateway.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<GetCurrencyRateUseCase>();
        return services;
    }
}
