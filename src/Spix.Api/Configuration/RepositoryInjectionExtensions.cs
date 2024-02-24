using Spix.Domain.Spixers;
using Spix.Domain.Users;
using Spix.Infra.Database.Repositories;

namespace Spix.Api.Configuration;

public static class RepositoryInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISpixerRepository, SpixerRepository>();
        services.AddScoped<IUserRepository, UserRepository>(); 
        return services;
    }       
}
