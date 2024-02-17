
namespace Spix.Domain.Abstraction;

public class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get;   }

    public DomainEvent()
    {
        OccurredOn = DateTime.Now;
    }
}
