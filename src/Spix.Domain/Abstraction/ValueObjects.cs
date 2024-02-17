namespace Spix.Domain.Abstraction;

public class ValueObjects
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if(rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }   
    }       
}
