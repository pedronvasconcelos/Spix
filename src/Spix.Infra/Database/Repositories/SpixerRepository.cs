using Microsoft.EntityFrameworkCore;
using Spix.Domain.Core;
using Spix.Domain.Spixers;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Database.Repositories;

public class SpixerRepository : ISpixerRepository
{
    private readonly SpixDbContext spixDbContext;
    private readonly DbSet<Spixer> Spixers;

    public SpixerRepository(SpixDbContext spixDbContext)
    {
        this.spixDbContext = spixDbContext;
        this.Spixers = spixDbContext.Spixers;
    }
    public IUnitOfWork UnitOfWork => spixDbContext;

    public async Task<Spixer> AddAsync(Spixer entity)
    {
        await Spixers.AddAsync(entity);
        return entity;  
    }

    public async Task DeleteAsync(Spixer entity)
    {
        await Task.Run(() => Spixers.Remove(entity));   

    }

    public void Dispose()
    {
       spixDbContext.Dispose();
    }

    public Task<Spixer?> GetByIdAsync(Guid id)
    {
        return Spixers.FirstOrDefaultAsync(x => x.Id == id);    
    }

    public Task UpdateAsync(Spixer entity)
    {
        Task.Run(() => Spixers.Update(entity));
        return Task.CompletedTask;
    }
}
