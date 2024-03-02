using Spix.Domain.Core;
using System.Text.RegularExpressions;

namespace Spix.Domain.Rules.Users;

public class EmailMustBeValidRule : IBusinessRule
{
    private readonly string _email;
    public EmailMustBeValidRule(string email)
    {
        _email = email;
    }
    public string Message => "Email bust be valid";

    public bool IsBroken()
     => !Regex.IsMatch(_email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
}
