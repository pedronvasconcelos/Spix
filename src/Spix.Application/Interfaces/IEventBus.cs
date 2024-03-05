
using Spix.Application.Core;

namespace Spix.Application.Interfaces;

public interface IEventBus
{
    Task PublishAsync<T>(
        T @event,
        CancellationToken cancellationToken = default)
        where T : class, IDomainEventNotification;
}