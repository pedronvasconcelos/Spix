namespace Spix.Domain.Users;

public interface IUserRepository
{
    public Task<User> AddAsync(User user);
    public Task<User> GetAsync(Guid id);
}
