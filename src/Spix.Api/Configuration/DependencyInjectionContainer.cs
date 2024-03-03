using Spix.Application.Interfaces;
using Spix.Infra.Keycloak;

namespace Spix.Api.Configuration;

public static class DependencyInjectionContainer
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, KeycloakClient>();
    }       
}
