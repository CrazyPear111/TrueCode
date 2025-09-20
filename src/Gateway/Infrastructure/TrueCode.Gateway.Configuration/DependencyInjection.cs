using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TrueCode.Gateway.Configuration;

public static class DependencyInjection
{
    public static AppSettings GetAppSettings(this IHostApplicationBuilder builder)
    {
        var appSettings = builder.Configuration.Get<AppSettings>()
            ?? throw new InvalidOperationException("Invalid configuration mapping.");

        builder.Services.AddSingleton(appSettings);
        return appSettings;
    }
}
