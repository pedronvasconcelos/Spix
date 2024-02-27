using MediatR;
using Microsoft.EntityFrameworkCore;

using Spix.Domain.Spixers;
using Spix.Infra.Extensions;
 
using Spix.Domain.Core;
using Spix.Domain.Users;
using Spix.Domain.Likes;

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
    public DbSet<UserSpix> Users { get; init; } 
    public DbSet<SpixerLike> SpixerLikes { get; init; }

    public  async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken) > 0;

        await this._mediator.DispatchDomainEventsAsync(this, cancellationToken);
        return result;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Ignore("_domainEvents");
            }
        }
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpixDbContext).Assembly);

    }


}
