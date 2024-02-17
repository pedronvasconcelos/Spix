using Spix.Domain.Abstraction;

namespace Spix.Domain.Users.Rules;

public class BirthdateCannotBeInFutureRule : IBusinessRule
{
    private readonly DateTime _birthdate;
    public BirthdateCannotBeInFutureRule(DateTime birthdate)
    {
        _birthdate = birthdate;
    }
    public string Message => "Birthdate cannot be in future";

    public bool IsBroken()
     => _birthdate.Date > DateTime.Now.Date;      
}
