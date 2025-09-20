using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.Data.Repositories;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data;

public static class DependencyInjection
{
    private readonly static string _connectionString;

    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddDbContext<ICurrencyContext, CurrencyContext>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        return services;
    }
}
