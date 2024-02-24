using MediatR;

namespace Spix.Application.Core;

public interface ICommandBase<TResponse> : IRequest<ResultBase<TResponse>> where TResponse : class
{
}


public class DomainEventPublishingDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _decorated;
    private readonly DomainEventPublisherService _publisher;

    public DomainEventPublishingDecorator(IRequestHandler<TRequest, TResponse> decorated, DomainEventPublisherService publisher)
    {
        _decorated = decorated;
        _publisher = publisher;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        // Executa o comando original
        var response = await _decorated.Handle(request, cancellationToken);

        // Publica os eventos de domínio
        // Aqui, você precisa passar o Agregado Raiz que contém os eventos
        await _publisher.PublishEventsAsync(aggregateRoot);

        return response;
    }
}
