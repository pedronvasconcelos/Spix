namespace Spix.Application.Spixers.Create;

public class CreateSpixerResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;

    public CreateSpixerResponse(Guid id, string content)
    {
        Id = id;
        Content = content;
    }
}