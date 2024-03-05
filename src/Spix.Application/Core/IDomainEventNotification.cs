using MediatR;
using Spix.Domain.SeedOfWork;

namespace Spix.Application.Core;

public interface IDomainEventNotification  : INotification 
{
    DomainEvent DomainEvent { get; }
    public Guid Id { get; }
}

public class DomainEventNotification : IDomainEventNotification 
{
    public DomainEvent DomainEvent { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public DomainEventNotification(DomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
        Id = Guid.NewGuid();      
    }
}