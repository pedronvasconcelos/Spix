using Spix.Application.Core;
using Spix.Application.Core.Errors;
using Spix.Domain.Core.Results;
using Spix.Domain.Entities;
using Spix.Domain.Repositories;

namespace Spix.Application.Spixers.Like;

public class LikeASpixerCommandHandler : ICommandHandlerBase<LikeASpixerCommand, LikeASpixerResponse>
{
    private readonly ISpixerRepository _spixerRepository;
    private readonly IUserRepository _userRepository;

    public LikeASpixerCommandHandler(ISpixerRepository spixerRepository, IUserRepository userRepository)
    {
        _spixerRepository = spixerRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<LikeASpixerResponse>> Handle(LikeASpixerCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.GetByIdAsync(request.UserId);  
        if (user == null)
        {
            return Result.Failure<LikeASpixerResponse>(ValidationErrors.User.NotFound);
        }   
        var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
            return Result.Failure<LikeASpixerResponse>(ValidationErrors.Spixer.NotFound);
        }
        if (await _spixerRepository.IsSpixerLikedByUserAsync(request.SpixerId, request.UserId))
        {
            return Result.Failure<LikeASpixerResponse>(ValidationErrors.Spixer.AlreadyLiked);
        }

        var spixerLike = new SpixerLike(spixer.Id, user.Id);    
        spixer.Like(spixerLike);

        
        await _spixerRepository.UpdateAsync(spixer);   
        await _spixerRepository.AddSpixerLikeAsync(spixerLike);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return Result.Failure<LikeASpixerResponse>(ValidationErrors.Database.Generic);
        }



        return Result.Success(
            new LikeASpixerResponse(
                spixerLike.Id, 
                user.Id, 
                spixer.Id,
                spixerLike.CreatedAt));          
    }
}
