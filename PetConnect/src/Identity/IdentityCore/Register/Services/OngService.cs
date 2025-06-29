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

public class OngService : IRegistrationService<OngRegisterDto>
{
    private readonly IRepository<Ong> _repository;
    private readonly IPasswordHasher _passwordHasher;

    public OngService(IRepository<Ong> repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(OngRegisterDto dto)
    {
        var passwordHash = _passwordHasher.HashPassword(dto.Password);

        var ong = OngMapper.ToEntity(dto, passwordHash);
        ong.SetPasswordHash(passwordHash);

        await _repository.AddAsync(ong);
    }
}
