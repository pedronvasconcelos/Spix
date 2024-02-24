using Spix.Domain.Core;
using Spix.Domain.Users.Rules;
using System.Text.RegularExpressions;

namespace Spix.Domain.Users;

public class Email : ValueObjects
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
        Vaidate();
    }

    public static implicit operator Email(string value) => new(value);

    public static implicit operator string(Email email) => email.Value;

    public override string ToString() => Value;

    public void Vaidate()
    {
        CheckRule(new EmailMustBeValidRule(Value));
    }
    public override bool Equals(object? obj)
    {
        if (obj is Email email)
        {
            return Value == email.Value;
        }

        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
