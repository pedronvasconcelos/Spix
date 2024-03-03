using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spix.Application.Core;
using Spix.Infra.EventBus.InMemory;

namespace Spix.Infra.BackgroundServices;

public sealed class EventProcessorJob(
    InMemoryMessageQueue queue,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<EventProcessorJob> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IDomainEventNotification @event in
            queue.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();

                IPublisher publisher = scope.ServiceProvider
                    .GetRequiredService<IPublisher>();

                await publisher.Publish(@event, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex.ToString(),
                    "Something went wrong! {IntegrationEventId}",
                    @event.Id);
            }
        }
    }
}