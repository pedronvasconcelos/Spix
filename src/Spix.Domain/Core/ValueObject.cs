namespace Spix.Domain.Core;

public class ValueObject
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if(rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }   
    }       
}
