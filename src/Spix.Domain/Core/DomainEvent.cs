
namespace Spix.Domain.Core;

public class DomainEvent  
{
    public DateTime OccurredOn { get;   }

    public DomainEvent()
    {
        OccurredOn = DateTime.UtcNow;
    }
}
