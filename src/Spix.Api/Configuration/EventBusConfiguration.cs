using Spix.Application.Interfaces;
using Spix.Infra.EventBus.InMemory;

namespace Spix.Api.Configuration;

public static class EventBusConfiguration 
{
    public static void AddEventBus(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryMessageQueue>();
        services.AddSingleton<IEventBus, InMemoryEventBus>();   

    }
}
