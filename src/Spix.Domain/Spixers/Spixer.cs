using Spix.Domain.Abstraction;
using Spix.Domain.Users;

namespace Spix.Domain.Spixers;

public class Spixer : Entity
{
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }

    public List<Guid> LikedByUsers { get; private set; } = new();
    public int LikesCount => LikedByUsers.Count;


    public void AddLike(Guid id)
    {
        if (!LikedByUsers.Contains(id))
        {
            LikedByUsers.Add(id);
        }
    }


}
