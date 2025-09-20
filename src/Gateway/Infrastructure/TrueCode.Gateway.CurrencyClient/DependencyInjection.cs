using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.Api;
using TrueCode.Gateway.Configuration;
using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.CurrencyClient;

public static class DependencyInjection
{
    public static IServiceCollection AddCurrencyClient(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddGrpcClient<Currency.CurrencyClient>(options =>
            {
                options.Address = new(appSettings.ConnectionStrings.CurrencyApi);
            });

        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        return services;
    }
}
