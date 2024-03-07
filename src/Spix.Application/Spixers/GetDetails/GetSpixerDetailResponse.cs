namespace Spix.Application.Spixers.GetDetails;

public record GetSpixerDetailResponse
{
    public string Content { get; } = null!;
    public DateTime CreatedAt { get; }
    public Guid Id { get; }
    public string Username { get; } = null!;
    public int Likes { get; }   
}