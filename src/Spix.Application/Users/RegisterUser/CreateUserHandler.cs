using Spix.Application.Core;
using Spix.Application.Interfaces;
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

    public async Task<ResultBase<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(request);
        if (!result)
        {
            return ResultBaseFactory.Failure<CreateUserResponse>("Failed to create user");
        }
        var entity =  await _userRepository.AddAsync(new UserSpix(request.Username, request.Email));
        await _userRepository.UnitOfWork.CommitAsync(cancellationToken);   
        if (entity == null)
        {
            return ResultBaseFactory.Failure<CreateUserResponse>("Failed to persist the user");  
        }

        return ResultBaseFactory.Successful(new CreateUserResponse(Guid.NewGuid(), entity.UserName, entity.Email, DateTime.Now), "User created successfully");
    }
}
 