using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<GetCurrencyRatesByUserUseCase>();
        services.AddTransient<UpdateCurrenciesUseCase>();
        services.AddTransient<AddFavoriteUseCase>();
        return services;
    }
}
