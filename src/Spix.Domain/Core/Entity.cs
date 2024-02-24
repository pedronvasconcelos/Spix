namespace Spix.Domain.Core;

public abstract class Entity
{
     public Guid Id { get; private set; } = Guid.NewGuid();

    public List<DomainEvent> _domainEvents = new List<DomainEvent>();


    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<DomainEvent>();
        this._domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
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


