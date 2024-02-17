namespace Spix.Domain.Abstraction;

public abstract class Entity
{
     public Guid Id { get; private set; } = Guid.NewGuid();

    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();


    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<IDomainEvent>();
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


