using Spix.Domain.Core;
using Spix.Domain.DomaiEvents;
using Spix.Domain.Rules;

namespace Spix.Domain.Entities;

public class Spixer : Entity, IAggregateRoot
{
    public string Content { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public Guid UserId { get; private set; }
    public virtual UserSpix User { get; private set; } = null!;

    public virtual List<SpixerLike> SpixerLikes { get; private set; } = new();     
    public int LikesCount { get; private set; }
    public bool Active { get; private set; } = true;


    public void Like(SpixerLike like)
    {
  
        SpixerLikes.Add(like);
        LikesCount++;
        AddDomainEvent(new SpixerLikedDomainEvent(this.Id, like.UserId));

    }

    public void Unlike(SpixerLike like)
    {
        SpixerLikes.Remove(like);
       LikesCount--;
    }


    public void Delete()
    {
        Active = false;
    }
    public Spixer(string content, Guid userId)
    {
        SetContent(content);
        UserId = userId;
        Active = true;
        CreatedAt = DateTime.UtcNow;    
    }

    public void DeleteSpixer()
    {
        Active = false;
    }
    private void SetContent(string content)
    {
        CheckRule(new ContentMustNotBeEmptyRule(content));
        CheckRule(new ContentMustNotExceedMaxLengthRule(content));

        Content = content;
    }

    public Spixer()
    { 
    }

}


