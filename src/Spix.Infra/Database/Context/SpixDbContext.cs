using MediatR;
using Microsoft.EntityFrameworkCore;
using Spix.Infra.Extensions;
using Spix.Domain.Entities;
using Spix.Application.Interfaces;
using Spix.Domain.Core.SeedOfWork;

namespace Spix.Infra.Database.Context;

public class SpixDbContext : DbContext, IUnitOfWork
{
  
    private readonly IEventBus _eventBus;
    public SpixDbContext(DbContextOptions<SpixDbContext> options, IEventBus eventBus)
        : base(options)
    {
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    }



    public DbSet<Spixer> Spixers { get; init; }
    public DbSet<UserSpix> Users { get; init; } 
    public DbSet<SpixerLike> SpixerLikes { get; init; }

    public  async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken) > 0;

        await this._eventBus.DispatchDomainEventsAsync(this, cancellationToken);
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
