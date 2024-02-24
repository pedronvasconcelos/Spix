using Spix.Domain.Users;

namespace Spix.Infra.Database.Repositories;

public class UserRepository : IUserRepository
{
    private  List<User> users = new();  
    public Task<User> AddAsync(User user)
    {
        users.Add(user);
        return Task.FromResult<User> (user);       
    }

    public Task<User> GetAsync(Guid id)
    {
        return Task.FromResult<User>(users.FirstOrDefault(x => x.Id == id));    
    }
}
