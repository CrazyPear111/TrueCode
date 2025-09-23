using Microsoft.Extensions.DependencyInjection;
using TrueCode.Gateway.Configuration;
using TrueCode.Gateway.UseCases.Interfaces;
using TrueCode.UserService.Api;

namespace TrueCode.Gateway.UserClient;

public static class DependencyInjection
{
    public static IServiceCollection AddUserClient(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddGrpcClient<Auth.AuthClient>(options =>
            {
                options.Address = new(appSettings.ConnectionStrings.UserApi);
            });

        services.AddScoped<IAuthRepository, AuthRepository>();
        return services;
    }
}
