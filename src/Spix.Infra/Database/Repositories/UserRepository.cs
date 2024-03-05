using Microsoft.EntityFrameworkCore;
using Spix.Domain.SeedOfWork;
using Spix.Domain.Entities;
using Spix.Domain.Repositories;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SpixDbContext spixDbContext;
    private readonly DbSet<UserSpix> Users;

    public UserRepository(SpixDbContext spixDbContext)
    {
        this.spixDbContext = spixDbContext;
        this.Users = spixDbContext.Users;
    }   
    public IUnitOfWork UnitOfWork => spixDbContext;

    public Task<UserSpix> AddAsync(UserSpix user)
    {
        Users.Add(user);
        return Task.FromResult<UserSpix> (user);       
    }

    public Task DeleteAsync(UserSpix entity)
    {
        Users.Remove(entity);   
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        spixDbContext.Dispose();    
    }

   

    public async Task<UserSpix?> GetByIdAsync(Guid id)
    {
        return await Users.FirstOrDefaultAsync(x => x.Id == id);    
    }

    public Task UpdateAsync(UserSpix entity)
    {
        return Task.Run(() => Users.Update(entity));    
    }
}
