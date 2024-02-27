using Spix.Application.Core;

namespace Spix.Api.Configuration;

public static class AppSettingsBinder
{
    public static void BindAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration);

    }
}
