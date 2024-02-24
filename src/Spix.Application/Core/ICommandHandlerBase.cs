using MediatR;

namespace Spix.Application.Core;

public interface ICommandHandlerBase<TCommand, TResponse> : IRequestHandler<TCommand, ResultBase<TResponse>>
    where TCommand : IRequest<ResultBase<TResponse>>
    where TResponse : class
{
}
