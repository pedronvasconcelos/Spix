
using Spix.Application.Core;
using Spix.Domain.Spixers;
using Spix.Domain.Users;

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
    public async Task<ResultBase<UnlikeASpixerResponse>> Handle(UnlikeASpixerCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return ResultBaseFactory.Failure<UnlikeASpixerResponse>("User not found");
        }
        var spixer = await _spixerRepository.GetByIdAsync(request.SpixerId);
        if (spixer == null)
        {
            return ResultBaseFactory.Failure<UnlikeASpixerResponse>("Spixer not found");
        }

        var like = await _spixerRepository.GetSpixerLikeAsync(request.SpixerId, request.UserId);    
        if(like == null)
        {
            return ResultBaseFactory.Failure<UnlikeASpixerResponse>("Spixer not liked");
        }

        spixer.Unlike(like);
        await _spixerRepository.DeleteSpixerLikeAsync(like);


        await _spixerRepository.UpdateAsync(spixer);
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return ResultBaseFactory.Failure<UnlikeASpixerResponse>("Error liking spixer");
        }



        return ResultBaseFactory.Successful(
            new UnlikeASpixerResponse(spixer.Id, request.UserId));
    }
}
