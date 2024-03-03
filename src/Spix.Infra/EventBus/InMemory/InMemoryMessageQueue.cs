using Spix.Application.Core;
using Spix.Domain.Core;
using System.Threading.Channels;

namespace Spix.Infra.EventBus.InMemory;

public sealed class InMemoryMessageQueue 
{
    private readonly Channel<IDomainEventNotification> _channel =
        Channel.CreateUnbounded<IDomainEventNotification>();

    public ChannelReader<IDomainEventNotification> Reader => _channel.Reader;

    public ChannelWriter<IDomainEventNotification> Writer => _channel.Writer;
}
