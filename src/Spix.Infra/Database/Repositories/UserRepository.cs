using Microsoft.EntityFrameworkCore;
using Spix.Domain.Core;
using Spix.Domain.Users;
using Spix.Infra.Database.Context;

namespace Spix.Infra.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SpixDbContext spixDbContext;
    private readonly DbSet<User> Users;

    public UserRepository(SpixDbContext spixDbContext)
    {
        this.spixDbContext = spixDbContext;
        this.Users = spixDbContext.Users;
    }   
    public IUnitOfWork UnitOfWork => spixDbContext;

    public Task<User> AddAsync(User user)
    {
        Users.Add(user);
        return Task.FromResult<User> (user);       
    }

    public Task DeleteAsync(User entity)
    {
        Users.Remove(entity);   
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        spixDbContext.Dispose();    
    }

   

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await Users.FirstOrDefaultAsync(x => x.Id == id);    
    }

    public Task UpdateAsync(User entity)
    {
        return Task.Run(() => Users.Update(entity));    
    }
}
