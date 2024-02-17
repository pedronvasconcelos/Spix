namespace Spix.Domain.Abstraction;

public abstract class Entity
{
     public Guid Id { get; private set; } = Guid.NewGuid();



    protected static void CheckRule(IBusinessRule rule)
    {
        if(rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }   
    }
}
