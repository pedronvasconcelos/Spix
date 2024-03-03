using Spix.Application.Users.RegisterUser;

namespace Spix.Application.Interfaces;

public interface IUserService
{
    Task<bool> CreateUserAsync(CreateUserCommand command);    
}
