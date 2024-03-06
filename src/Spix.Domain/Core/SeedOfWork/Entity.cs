using Spix.Domain.Core.Results;

namespace Spix.Domain.Core.SeedOfWork;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public List<DomainEvent> _domainEvents = new List<DomainEvent>();


    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<DomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
    protected static Result CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            return Result.ValidateRule(rule);
        }
        return Result.Success();    
    }

    protected static Result CheckRule(params IBusinessRule[] rules)
    {
        foreach (var rule in rules)
        {
            if (rule.IsBroken())
            {
                return Result.ValidateRule(rule);
            }
        }
        return Result.Success();
    }       
}


