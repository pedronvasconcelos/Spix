using MediatR;
using Spix.Domain.Core;

namespace Spix.Application.Core;

public interface IDomainEventNotification<T> : INotification where T : DomainEvent
{
    T DomainEvent { get; }
}