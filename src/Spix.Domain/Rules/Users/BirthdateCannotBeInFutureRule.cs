using Spix.Domain.SeedOfWork;

namespace Spix.Domain.Rules.Users;

public class BirthdateCannotBeInFutureRule : IBusinessRule
{
    private readonly DateTime _birthdate;
    public BirthdateCannotBeInFutureRule(DateTime birthdate)
    {
        _birthdate = birthdate;
    }
    public string Message => "Birthdate cannot be in future";

    public bool IsBroken()
     => _birthdate.Date > DateTime.UtcNow.Date;
}
