using Spix.Domain.Core;
using Spix.Domain.ValueObjects;

namespace Spix.Domain.Entities;

public class UserSpix : Entity, IAggregateRoot
{

    public Username UserName { get; private set; }
    public UserAttributes? Attributes { get; private set; }

    public Email Email { get; private set; }
    public string? Biography { get; private set; } = null;

    public List<Spixer> Spixers { get; private set; } = new();
    public List<SpixerLike> SpixerLikes { get; private set; } = new();
    public ICollection<UserFollower> Following { get; private set; }
    public ICollection<UserFollower> Followers { get; private set; }



    public bool EmailIsVerified { get; private set; }
    public bool IsActive { get; private set; }
    public string Location { get; private set; }
    public string WebSite { get; set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; } = null;

    public IReadOnlyList<Spixer> GetSpixers() => Spixers.AsReadOnly();

    public IReadOnlyList<SpixerLike> GetSpixerLikes() => SpixerLikes.AsReadOnly();

    public bool IsConfirmed() => EmailIsVerified && IsActive;
    public bool IsComplete() => Attributes is not null;
    public UserSpix(string userName, Email email)
    {
        UserName = userName;
        Email = email;
        EmailIsVerified = false;
        IsActive = true;
        Location = "Unknown";
        WebSite = "Unknown";
    }

    public UserSpix()
    {

    }


}


public class UserFollower
{
    public Guid UserId { get; set; }
    public UserSpix User { get; set; }

    public Guid FollowerId { get; set; }
    public UserSpix Follower { get; set; }

    public UserFollower(Guid userId, Guid followerId)
    {
        UserId = userId;
        FollowerId = followerId;
    }

}