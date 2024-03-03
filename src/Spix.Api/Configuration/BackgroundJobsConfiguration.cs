using Spix.Infra.BackgroundServices;

namespace Spix.Api.Configuration;


public static class BackgroundJobsConfiguration
{
    public static void AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddHostedService<EventProcessorJob>();
    }
}
