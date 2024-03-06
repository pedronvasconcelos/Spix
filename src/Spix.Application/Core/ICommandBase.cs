using MediatR;
using Spix.Domain.Core.Results;

namespace Spix.Application.Core;

public interface ICommandBase<TResponse> : IRequest<Result<TResponse>> where TResponse : class
{
}

 