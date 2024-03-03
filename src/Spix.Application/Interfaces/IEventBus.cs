
using Spix.Application.Core;
using Spix.Domain.Core;

namespace Spix.Application.Interfaces;

public interface IEventBus
{
    Task PublishAsync<T>(
        T @event,
        CancellationToken cancellationToken = default)
        where T : class, IDomainEventNotification;
}