using Microsoft.Extensions.DependencyInjection;

namespace TrueCode.Gateway.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<GetCurrencyRateUseCase>();
        services.AddTransient<AddFavoriteUseCase>();
        services.AddTransient<RegisterUseCase>();
        services.AddTransient<LoginUseCase>();
        return services;
    }
}
