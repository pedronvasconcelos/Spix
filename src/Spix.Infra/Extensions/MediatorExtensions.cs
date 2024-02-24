using MediatR;
using Spix.Application.Core;
using Spix.Domain.Core;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Extensions;


public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, SpixDbContext ctx, CancellationToken cancellationToken)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity._domainEvents != null && x.Entity._domainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity._domainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                var notification = new DomainEventNotification<DomainEvent>(domainEvent);
                await mediator.Publish(notification, cancellationToken);
            });

        await Task.WhenAll(tasks);
    }

}