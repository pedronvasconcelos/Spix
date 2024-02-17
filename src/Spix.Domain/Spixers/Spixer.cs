using Spix.Domain.Abstraction;
using Spix.Domain.Spixers.Rules;
using Spix.Domain.Users;

namespace Spix.Domain.Spixers;

public class Spixer : Entity, IAggregateRoot
{
    public string Content { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; } = null!;

    public List<Guid> LikedByUsers { get; private set; } = new();
    public int LikesCount => LikedByUsers.Count;


    public void AddLike(Guid userId)
    {
        if (!LikedByUsers.Contains(userId))
        {
            LikedByUsers.Add(userId);
        }
        AddDomainEvent(new SpixerLikedDomainEvent(this.Id, userId));

    }

    public void RemoveLike(Guid userId)
    {
        if (LikedByUsers.Contains(userId))
        {
            LikedByUsers.Remove(userId);
        }
    }

    
     public Spixer(string content, Guid userId)
    {
        SetContent(content);
          UserId = userId;
     }

    private void SetContent(string content)
    {
        CheckRule(new ContentMustNotBeEmptyRule(content));
        CheckRule(new ContentMustNotExceedMaxLengthRule(content));

        Content = content;
    }



}
