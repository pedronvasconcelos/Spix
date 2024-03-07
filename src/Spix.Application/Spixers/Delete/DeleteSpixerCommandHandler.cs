using Spix.Application.Core;
using Spix.Application.Core.Errors;
using Spix.Domain.Core.Results;
using Spix.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Spix.Application.Spixers.Delete;

public class DeleteSpixerCommandHandler : ICommandHandlerBase<DeleteSpixerCommand, DeleteSpixerResponse>
{
    private readonly ISpixerRepository _spixerRepository;
    
    public DeleteSpixerCommandHandler(ISpixerRepository spixerRepository)
    {
        _spixerRepository = spixerRepository;
     }

    public async Task<Result<DeleteSpixerResponse>> Handle(DeleteSpixerCommand request, CancellationToken cancellationToken)
    {

       var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
            return Result.Failure<DeleteSpixerResponse>(ValidationErrors.Spixer.NotFound) ;
        }

        if (spixer.UserId != request.UserId)
        {
            return Result.Failure<DeleteSpixerResponse>(ValidationErrors.Spixer.UserCantDelete);
        }

        spixer.Delete();    
        await _spixerRepository.UpdateAsync(spixer);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return Result.Failure<DeleteSpixerResponse>(ValidationErrors.Database.Generic);
        }
        return Result.Success(new DeleteSpixerResponse { DeletedAt = DateTime.UtcNow });               
    }
}
