using MediatR;

namespace Spix.Application.Core;

public interface IQuery<TResponse> : IRequest<TResponse>
{

}

