using Spix.Application.Core;
using Spix.Application.Core.Errors;
using Spix.Domain.Core.Results;
using Spix.Domain.Entities;
using Spix.Domain.Repositories;

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

    public async Task<Result<CreateSpixerResponse>> Handle(CreateSpixerCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return Result.Failure<CreateSpixerResponse>(ValidationErrors.User.NotFound);
        }
       
        var spixer = new Spixer(request.Content, user.Id);
        var addedSpixer = await _spixerRepository.AddAsync(spixer);
       
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return Result.Failure<CreateSpixerResponse>(ValidationErrors.Database.Generic);
        }   
        return Result.Success(new CreateSpixerResponse(addedSpixer.Id, addedSpixer.Content));
    }
}
