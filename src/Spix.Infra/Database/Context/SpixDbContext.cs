using MediatR;
using Microsoft.EntityFrameworkCore;
using Spix.Infra.Extensions;

namespace Spix.Infra.Database.Context;

public class SpixDbContext : DbContext
{
  
    private readonly IMediator _mediator;
    public SpixDbContext(DbContextOptions<SpixDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await this._mediator.DispatchDomainEventsAsync(this, cancellationToken);    
        return await base.SaveChangesAsync(cancellationToken);
    }

}
