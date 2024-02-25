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
    public  List<Guid> Followers { get; private set; } = new();
    public List<Guid> Following { get; private set; } = new();



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
    //construtor 
    public User(string userName, Email email)
    {
        UserName = userName;
        Email = email;
        EmailIsVerified = false;
        IsActive = true;
    }

    public User()
    {

    }


}
