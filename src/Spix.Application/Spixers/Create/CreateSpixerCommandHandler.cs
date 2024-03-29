﻿using Spix.Application.Core;
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

    public async Task<ResultBase<CreateSpixerResponse>> Handle(CreateSpixerCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return ResultBaseFactory.Failure<CreateSpixerResponse>("User not found");
        }
       
        var spixer = new Spixer(request.Content, user.Id);
        var addedSpixer = await _spixerRepository.AddAsync(spixer);
       
        if (!await _spixerRepository.UnitOfWork.CommitAsync(cancellationToken))
        {
            return ResultBaseFactory.Failure<CreateSpixerResponse>("Error adding spixer");
        }   
        return ResultBaseFactory.Successful(new CreateSpixerResponse(addedSpixer.Id, addedSpixer.Content), "Success");
    }
}
