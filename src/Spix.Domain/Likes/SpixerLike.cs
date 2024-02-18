using Spix.Domain.Core;
using Spix.Domain.Spixers;
using Spix.Domain.Users;

namespace Spix.Domain.Likes;

public class SpixerLike : Entity
{
    public Guid SpixerId { get; private set; }
    public virtual Spixer Spixer { get; private set; }
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;


}
