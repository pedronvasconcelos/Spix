using Spix.Application.Core;

namespace Spix.Application.Spixers.Unlike;

public class UnlikeASpixerCommand : ICommandBase<UnlikeASpixerResponse>    
{
    public Guid UserId { get; set; }
    public Guid SpixerId { get; set; }
}
