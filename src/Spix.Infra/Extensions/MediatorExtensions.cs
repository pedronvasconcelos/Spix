using MediatR;
using Spix.Application.Core;
using Spix.Application.Interfaces;
using Spix.Domain.Core;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Extensions;


public static class EventBusExtensions
{
    public static async Task DispatchDomainEventsAsync(this IEventBus eventBus, SpixDbContext ctx, CancellationToken cancellationToken)
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
                var notification = new DomainEventNotification(domainEvent);
                await eventBus.PublishAsync(notification, cancellationToken);
            });

        await Task.WhenAll(tasks);
    }

}