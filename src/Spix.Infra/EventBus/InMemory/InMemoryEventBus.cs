using Spix.Application.Core;
using Spix.Application.Interfaces;

namespace Spix.Infra.EventBus.InMemory;

public sealed class InMemoryEventBus(InMemoryMessageQueue queue) : IEventBus
{
    public async Task PublishAsync<T>(
        T @event,
        CancellationToken cancellationToken = default)
        where T : class, IDomainEventNotification
    {
        await queue.Writer.WriteAsync(@event, cancellationToken);
    }

}