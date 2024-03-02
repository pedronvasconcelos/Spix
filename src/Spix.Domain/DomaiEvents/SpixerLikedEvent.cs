using Spix.Domain.Core;

namespace Spix.Domain.DomaiEvents;

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
