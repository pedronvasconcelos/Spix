
using Spix.Application.Core;
using Spix.Application.Core.Errors;
using Spix.Domain.Core.Results;
using Spix.Domain.Repositories;

namespace Spix.Application.Spixers.Unlike;

public class UnlikeASpixerCommandHandler : ICommandHandlerBase<UnlikeASpixerCommand, UnlikeASpixerResponse>
{
    private readonly ISpixerRepository _spixerRepository;
    private readonly IUserRepository _userRepository;

    public UnlikeASpixerCommandHandler(ISpixerRepository spixerRepository, IUserRepository userRepository)
    {
        _spixerRepository = spixerRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<UnlikeASpixerResponse>> Handle(UnlikeASpixerCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return Result.Failure<UnlikeASpixerResponse>(ValidationErrors.User.NotFound);
        }
        var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
            return Result.Failure<UnlikeASpixerResponse>(ValidationErrors.Spixer.NotFound);
        }

        var like = await _spixerRepository.GetSpixerLikeAsync(request.SpixerId, request.UserId);    
        if(like == null)
        {
            return Result.Failure<UnlikeASpixerResponse>(ValidationErrors.Spixer.NotLiked);
        }

        spixer.Unlike(like);
        await _spixerRepository.DeleteSpixerLikeAsync(like);


        await _spixerRepository.UpdateAsync(spixer);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return Result.Failure<UnlikeASpixerResponse>(ValidationErrors.Database.Generic);
        }



        return Result.Success(
            new UnlikeASpixerResponse(spixer.Id, request.UserId));
    }
}
