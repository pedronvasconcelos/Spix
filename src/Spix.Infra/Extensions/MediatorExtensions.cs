using MediatR;

namespace Spix.Infra.Extensions;

public static class MediatorExtensions
{
   public static async Task<TResponse> Execute<TResponse>(this IMediator mediator, IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
       
        var response = await mediator.Send(request, cancellationToken);
        return response;
    }
}