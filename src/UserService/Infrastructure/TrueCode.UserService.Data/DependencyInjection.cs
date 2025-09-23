using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrueCode.UserService.Configuration;
using TrueCode.UserService.UseCases.Interfaces;

namespace TrueCode.UserService.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, AppSettings appSettings)
    {
        var connectionString = appSettings.ConnectionStrings.UserDB;
        //connectionString = "Host=localhost;Port=8432;Database=truecode_user_db;Username=db_admin;Password=password";
        services.AddDbContext<IUserDbContext, UserDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
