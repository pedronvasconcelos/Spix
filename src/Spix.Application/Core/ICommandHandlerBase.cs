using MediatR;
using Spix.Domain.Core.Results;

namespace Spix.Application.Core;

public interface ICommandHandlerBase<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : IRequest<Result<TResponse>>
    where TResponse : class
{
}
