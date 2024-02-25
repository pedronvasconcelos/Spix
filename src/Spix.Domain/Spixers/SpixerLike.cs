using Spix.Domain.Core;
using Spix.Domain.Spixers;
using Spix.Domain.Users;

namespace Spix.Domain.Likes;

public class SpixerLike : Entity
{
    public Guid SpixerId { get; private set; }
    public virtual Spixer Spixer { get; private set; } = null!;
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public SpixerLike(Guid spixerId, Guid userId)
    {
        SpixerId = spixerId;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    private SpixerLike()
    {
    }


}
