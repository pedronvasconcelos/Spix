using MediatR;

namespace Spix.Application.Core;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
      where TQuery : IQuery<TResponse>
{
}

