using Spix.Application.Core;
using Spix.Domain.Likes;
using Spix.Domain.Spixers;
using Spix.Domain.Users;

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
    public async Task<ResultBase<LikeASpixerResponse>> Handle(LikeASpixerCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.GetByIdAsync(request.UserId);  
        if (user == null)
        {
            return ResultBaseFactory.Failure<LikeASpixerResponse>("User not found");
        }   
        var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
            return ResultBaseFactory.Failure<LikeASpixerResponse>("Spixer not found");
        }
        if (await _spixerRepository.IsSpixerLikedByUserAsync(request.SpixerId, request.UserId))
        {
            return ResultBaseFactory.Failure<LikeASpixerResponse>("Spixer already liked");
        }

        var spixerLike = new SpixerLike(spixer.Id, user.Id);    
        spixer.Like(spixerLike);

        
        await _spixerRepository.UpdateAsync(spixer);   
        await _spixerRepository.AddSpixerLikeAsync(spixerLike);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return ResultBaseFactory.Failure<LikeASpixerResponse>("Error liking spixer");
        }



        return ResultBaseFactory.Successful(
            new LikeASpixerResponse(
                spixerLike.Id, 
                user.Id, 
                spixer.Id,
                spixerLike.CreatedAt),
                "Success");          
    }
}
