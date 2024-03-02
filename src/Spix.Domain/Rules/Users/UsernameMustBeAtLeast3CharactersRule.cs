using Spix.Domain.Core;
using Spix.Domain.ValueObjects;

namespace Spix.Domain.Rules.Users;

public class UsernameMustBeAtLeast3CharactersRule : IBusinessRule
{
    private readonly string _username;

    public UsernameMustBeAtLeast3CharactersRule(string username)
    {
        _username = username;
    }

    public string Message => "Username must be at least 3 characters long";

    public bool IsBroken() => _username.Length < Username.MinLength;
}