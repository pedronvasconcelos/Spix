namespace Spix.Domain.Core;

public abstract class Entity
{
     public Guid Id { get; private set; } = Guid.NewGuid();

    private List<DomainEvent> _domainEvents = new List<DomainEvent>();


    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<DomainEvent>();
        this._domainEvents.Add(domainEvent);
    }

    protected void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }   
    protected static void CheckRule(IBusinessRule rule)
    {
        if(rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }   
    }
}


