using Spix.Domain.Core.SeedOfWork;

namespace Spix.Domain.Rules.Users;

public class UsernameCannotBeEmptyRule : IBusinessRule
{
    private readonly string _username;

    public UsernameCannotBeEmptyRule(string username)
    {
        _username = username;
    }

    public string Message => "Username cannot be empty";

    public bool IsBroken() => string.IsNullOrWhiteSpace(_username);
}