using Microsoft.EntityFrameworkCore;
using Spix.Domain.SeedOfWork;
using Spix.Domain.Entities;
using Spix.Domain.Repositories;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Database.Repositories;

public class SpixerRepository : ISpixerRepository
{
    private readonly SpixDbContext spixDbContext;
    private readonly DbSet<Spixer> Spixers;
    private readonly DbSet<SpixerLike> SpixerLikes; 

    public SpixerRepository(SpixDbContext spixDbContext)
    {
        this.spixDbContext = spixDbContext;
        this.Spixers = spixDbContext.Spixers;
        this.SpixerLikes = spixDbContext.SpixerLikes;
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

    public async Task<bool> IsSpixerLikedByUserAsync(Guid spixerId, Guid userId)
    {
        return await Spixers.AnyAsync(x => x.Id == spixerId && x.SpixerLikes.Any(x => x.UserId == userId));
    }
    public async Task AddSpixerLikeAsync(SpixerLike spixerLike)
    {
        await SpixerLikes.AddAsync(spixerLike);
    }

    public async Task<SpixerLike?> GetSpixerLikeAsync(Guid spixerId, Guid userId)
    {
        return await SpixerLikes.FirstOrDefaultAsync(x => x.SpixerId == spixerId && x.UserId == userId);
    }   
    public async Task DeleteSpixerLikeAsync(SpixerLike spixerLike)
    {
        await Task.Run(() => SpixerLikes.Remove(spixerLike));
    }       

}
