using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrueCode.CurrencyService.Configuration;
using TrueCode.CurrencyService.Data.Repositories;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, AppSettings appSettings)
    {
        var connectionString = appSettings.ConnectionStrings.CurrencyDB;
        //connectionString = "Host=localhost;Port=7432;Database=truecode_currency_db;Username=db_admin;Password=password";
        services.AddDbContext<ICurrencyContext, CurrencyContext>(options => 
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
