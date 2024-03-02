namespace Spix.Application.Users.RegisterUser;

public class CreateUserResponse 
{
    public Guid Id { get;  }
    public string Username { get; }
    public string Email { get;   }
    public DateTime CreatedAt { get; }

    public CreateUserResponse(Guid id, string username, string email, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Email = email;
        CreatedAt = createdAt;
    }

}
