

using Microsoft.EntityFrameworkCore;
using Spix.Infra.Database.Context;

namespace Spix.Api.Configuration;

public static class DbContextConfiguration
{

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SpixDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
