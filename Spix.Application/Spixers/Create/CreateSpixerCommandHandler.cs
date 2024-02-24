using Spix.Application.Core;
using Spix.Domain.Spixers;
using Spix.Domain.Users;

namespace Spix.Application.Spixers.Create;

public class CreateSpixerCommandHandler : ICommandHandlerBase<CreateSpixerCommand, CreateSpixerResponse>
{
    private readonly ISpixerRepository _spixerRepository;
    private readonly IUserRepository _userRepository;

    public CreateSpixerCommandHandler(ISpixerRepository spixerRepository, IUserRepository userRepository)
    {
        _spixerRepository = spixerRepository;
        _userRepository = userRepository;
    }

    public async Task<ResultBase<CreateSpixerResponse>> Handle(CreateSpixerCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.UserId);
        if (user == null)
        {
            return ResultBaseFactory.Failure<CreateSpixerResponse>("User not found");
        }
        var spixer = new Spixer(request.Content, user.Id);
        var addedSpixer = await _spixerRepository.AddAsync(spixer);
        return ResultBaseFactory.Successful(new CreateSpixerResponse(addedSpixer.Id, addedSpixer.Content), "Successs");

    }
}
