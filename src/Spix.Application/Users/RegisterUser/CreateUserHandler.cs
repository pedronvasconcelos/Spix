using Spix.Application.Core;
using Spix.Application.Core.Errors;
using Spix.Application.Interfaces;
using Spix.Domain.Core.Results;
using Spix.Domain.Entities;
using Spix.Domain.Repositories;

namespace Spix.Application.Users.RegisterUser;

public class CreateUserHandler : ICommandHandlerBase<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    public CreateUserHandler(IUserService userService,
        IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;   
    }

    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(request);
        if (!result)
        {
            return Result.Failure<CreateUserResponse>(ValidationErrors.User.ErrorCreatingUser);
        }
        var entity =  await _userRepository.AddAsync(new UserSpix(request.Username, request.Email));
        await _userRepository.UnitOfWork.CommitAsync(cancellationToken);   
        if (entity == null)
        {
            return Result.Failure<CreateUserResponse>(ValidationErrors.Database.Generic);  
        }

        return Result.Success(new CreateUserResponse(Guid.NewGuid(), entity.UserName, entity.Email, DateTime.Now));
    }
}
 