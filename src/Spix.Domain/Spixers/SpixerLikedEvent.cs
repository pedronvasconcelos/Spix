using Spix.Domain.Abstraction;
 

namespace Spix.Domain.Spixers;

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
