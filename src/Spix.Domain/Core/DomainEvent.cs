
namespace Spix.Domain.Core;

public class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get;   }

    public DomainEvent()
    {
        OccurredOn = DateTime.Now;
    }
}
