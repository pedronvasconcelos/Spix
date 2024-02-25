using Spix.Application.Core;

namespace Spix.Application.Spixers.Delete;

public class DeleteSpixerCommand : ICommandBase<DeleteSpixerResponse>   
{
    public Guid UserId { get; set; }
    public Guid SpixerId { get; set; }  

    public DeleteSpixerCommand(Guid userId, Guid spixerId)
    {
        UserId = userId;
        SpixerId = spixerId;
    }
}
