namespace Spix.Domain.Core.SeedOfWork;

public class DomainEvent
{
    public DateTime OccurredOn { get; }

    public DomainEvent()
    {
        OccurredOn = DateTime.UtcNow;
    }
}
