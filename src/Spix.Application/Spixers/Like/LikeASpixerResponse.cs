namespace Spix.Application.Spixers.Like;

public class LikeASpixerResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SpixerId { get; set; }
    public DateTime CreatedAt { get; set; }

    public LikeASpixerResponse(Guid id, Guid userId, Guid spixerId, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        SpixerId = spixerId;
        CreatedAt = createdAt;
    }
}
