
using Spix.Application.Users.Models;

namespace Spix.Infra.Keycloak;

public class UserRepresentation
{
    public string Origin { get; private set; }
    public string Username { get; private set; }
    public bool Enabled { get; private set; }
    public bool EmailVerified { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public List<CredentialRepresentation> Credentials { get; private set; }
    public List<string> RealmRoles { get; private set; } = new List<string>();
    public UserRepresentation(string username, string email, string firstName, string lastName, string password, bool enabled = true)
    {
        Origin = "Spix";
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Enabled = enabled;
        EmailVerified = true;
        Credentials = new List<CredentialRepresentation> { CredentialRepresentation.Password(password) };
        RealmRoles = new List<string> { "default-user" };
    }

    public static UserRepresentation FromCommand (CreateUserCommand command)
    {
        return new UserRepresentation(command.Username, command.Email, command.FirstName, command.LastName, command.Password);
    }   

}

public class CredentialRepresentation
{
    public string Type { get; private set; }
    public string Value { get; private set; }
    public bool Temporary { get; private set; }

    public CredentialRepresentation(string type, string value, bool temporary)
    {
        Type = type;
        Value = value;
        Temporary = temporary;
    }

    public static CredentialRepresentation Password(string password, bool temporary = false)
    {
        return new CredentialRepresentation("password", password, temporary);
    }       
}       