namespace Spix.Application.Spixers.Unlike;

public class UnlikeASpixerResponse
{
    public Guid SpixerId { get; set; }  
    public Guid UserId { get; set; }

    public UnlikeASpixerResponse(Guid spixerId, Guid userId)
    {
        SpixerId = spixerId;
        UserId = userId;
    }
}