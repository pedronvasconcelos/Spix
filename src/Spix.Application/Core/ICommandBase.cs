using MediatR;

namespace Spix.Application.Core;

public interface ICommandBase<TResponse> : IRequest<ResultBase<TResponse>> where TResponse : class
{
}

 