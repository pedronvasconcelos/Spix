using Spix.Domain.SeedOfWork;
using Spix.Domain.ValueObjects;

namespace Spix.Domain.Rules.Users;

public class UsernameMaxCharactersRule : IBusinessRule
{
    private readonly string _username;

    public UsernameMaxCharactersRule(string username)
    {
        _username = username;
    }

    public string Message => $"Username must be at most {Username.MaxLength} characters long";

    public bool IsBroken() => _username.Length > Username.MaxLength;
}