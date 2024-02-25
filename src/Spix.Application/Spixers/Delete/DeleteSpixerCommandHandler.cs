using Spix.Application.Core;
using Spix.Domain.Spixers;

namespace Spix.Application.Spixers.Delete;

public class DeleteSpixerCommandHandler : ICommandHandlerBase<DeleteSpixerCommand, DeleteSpixerResponse>
{
    private readonly ISpixerRepository _spixerRepository;
    
    public DeleteSpixerCommandHandler(ISpixerRepository spixerRepository)
    {
        _spixerRepository = spixerRepository;
     }

    public async Task<ResultBase<DeleteSpixerResponse>> Handle(DeleteSpixerCommand request, CancellationToken cancellationToken)
    {

       var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
              return ResultBaseFactory.Failure<DeleteSpixerResponse>("Spixer not found");
        }

        if (spixer.UserId != request.UserId)
        {
            return ResultBaseFactory.Failure<DeleteSpixerResponse>("User not authorized to delete this spixer");
        }

        spixer.Delete();    
        await _spixerRepository.UpdateAsync(spixer);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return ResultBaseFactory.Failure<DeleteSpixerResponse>("Error deleting spixer");
        }
        return ResultBaseFactory.Successful(new DeleteSpixerResponse { DeletedAt = DateTime.UtcNow }, "Success");               
    }
}
