using Spix.Domain.Core.SeedOfWork;
using Spix.Domain.Rules.Users;

namespace Spix.Domain.ValueObjects;

public sealed class Username : ValueObject
{
    public const int MaxLength = 50;
    public const int MinLength = 3;

    public string Value { get; private set; }

    public Username(string value)
    {
        CheckRule(new UsernameCannotBeEmptyRule(value));
        CheckRule(new UsernameMustBeAtLeast3CharactersRule(value));
        CheckRule(new UsernameMaxCharactersRule(value));

        Value = value;
    }



    public static implicit operator Username(string value)
    {
        return new Username(value);
    }

    public static implicit operator string(Username userName)
    {
        return userName.Value;
    }


}
