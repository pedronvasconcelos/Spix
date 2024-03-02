using Spix.Application.Core;
using Spix.Application.Interfaces;

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


//handler 
public class CreateUserHandler : ICommandHandlerBase<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResultBase<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request);
        return ResultBaseFactory.Successful(new CreateUserResponse(Guid.NewGuid(), "", "", DateTime.Now)); ;
    }
}
 