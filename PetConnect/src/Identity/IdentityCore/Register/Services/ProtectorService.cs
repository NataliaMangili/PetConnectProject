using IdentityCore.Domain.Entities;
using IdentityCore.Interfaces;
using IdentityCore.Register.DTOs;
using IdentityCore.Register.Interfaces;
using IdentityCore.Register.Mappers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Register.Services;

public class ProtectorService : IRegistrationService<ProtectorRegisterDto>
{
    private readonly IRepository<Protector> _repository;
    private readonly IPasswordHasher _passwordHasher;

    public ProtectorService(IRepository<Protector> repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(ProtectorRegisterDto dto)
    {
        var passwordHash = _passwordHasher.HashPassword(dto.Password);

        var protector = ProtectorMapper.ToEntity(dto, passwordHash);
        protector.SetPasswordHash(passwordHash);

        await _repository.AddAsync(protector);
    }
}

