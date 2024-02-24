using MediatR;
using Spix.Domain.Core;

namespace Spix.Application.Core;

public interface IDomainEventNotification<T> : INotification where T : DomainEvent
{
    T DomainEvent { get; }
}

public class DomainEventNotification<T> : IDomainEventNotification<T> where T : DomainEvent
{
    public T DomainEvent { get; }

    public DomainEventNotification(T domainEvent)
    {
        DomainEvent = domainEvent;
    }
}