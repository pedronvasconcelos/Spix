
using MediatR;
using Spix.Application.Core;

namespace Spix.Application.Spixers.Create;

public class CreateSpixerCommand : ICommandBase<CreateSpixerResponse>
{
    public string Content { get; set; } = null!;    
    public Guid UserId { get; set; }
}
