using Spix.Application.Users.Models;

namespace Spix.Application.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(CreateUserCommand command);    
}
