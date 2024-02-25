using Spix.Domain.Core;
using Spix.Domain.Likes;
using Spix.Domain.Spixers;

namespace Spix.Domain.Users;

public class User : Entity, IAggregateRoot
{

    public string UserName { get; private set; }
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
    public User(string userName, Email email)
    {
        UserName = userName;
        Email = email;
        EmailIsVerified = false;
        IsActive = true;
        Location = "Unknown";
        WebSite = "Unknown";    
    }

    public User()
    {

    }


}


public class UserFollower
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid FollowerId { get; set; }
    public User Follower { get; set; }
}