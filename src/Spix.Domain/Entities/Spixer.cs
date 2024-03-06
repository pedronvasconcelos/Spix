using Spix.Domain.Core.Results;
using Spix.Domain.Core.SeedOfWork;
using Spix.Domain.Events;
using Spix.Domain.Rules.Spixers;

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


    public Result Like(SpixerLike like)
    {
  
        SpixerLikes.Add(like);
        LikesCount++;
        AddDomainEvent(new SpixerLikedDomainEvent(this.Id, like.UserId));
        return Result.Success();
    }

    public Result Unlike(SpixerLike like)
    {

       SpixerLikes.Remove(like);
       LikesCount--;
       return Result.Success();
    }


    public Result Delete()
    {
        if(!Active)
            return Result.Failure(Error.None);  
        Active = false;
        return Result.Success();
    }
    public Spixer(string content, Guid userId)
    {
        Content = content;
        UserId = userId;
        Active = true;
        CreatedAt = DateTime.UtcNow;    
    }

    public static Result<Spixer> Create(string content, Guid userId)
    {
        Result result = CheckRule(new ContentMustNotBeEmptyRule(content), new ContentMustNotExceedMaxLengthRule(content));  
        if(result.IsFailure)
            return Result.Failure<Spixer>(result.Error);        


        return new Spixer(content, userId);
    }       
   
    private Result SetContent(string content)
    {
         
        Result result = CheckRule(new ContentMustNotBeEmptyRule(content), new ContentMustNotExceedMaxLengthRule(content));
        
        if(result.IsFailure)
            return result;  

        Content = content;
        return result;
    }

    public Spixer()
    { 
    }

}


