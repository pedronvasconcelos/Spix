using MediatR;
using Microsoft.EntityFrameworkCore;

using Spix.Domain.Spixers;
using Spix.Infra.Extensions;
 
using Spix.Domain.Core;

namespace Spix.Infra.Database.Context;

public class SpixDbContext : DbContext, IUnitOfWork
{
  
    private readonly IMediator _mediator;
    public SpixDbContext(DbContextOptions<SpixDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    public DbSet<Spixer> Spixers { get; init; }

    public  async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        await this._mediator.DispatchDomainEventsAsync(this, cancellationToken);    
        return await base.SaveChangesAsync(cancellationToken) > 0 ;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpixDbContext).Assembly);

    }


}
