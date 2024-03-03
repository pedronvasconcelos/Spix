using Spix.Application.Core;

namespace Spix.Application.Users.RegisterUser;

public class CreateUserCommand : ICommandBase<CreateUserResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }

    public CreateUserCommand(string username, string email, string firstName, string lastName, string password)
    {
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }

}
 