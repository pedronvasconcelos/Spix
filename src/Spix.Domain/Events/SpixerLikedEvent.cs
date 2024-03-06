using Spix.Domain.Core.SeedOfWork;

namespace Spix.Domain.Events;

public class SpixerLikedDomainEvent : DomainEvent
{
    public Guid SpixerId { get; }
    public Guid UserId { get; }

    public SpixerLikedDomainEvent(Guid spixerId, Guid userId)
    {
        SpixerId = spixerId;
        UserId = userId;
    }

}
