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

public class UserService : IRegistrationService<UserRegisterDto>
{
    private readonly IRepository<User> _repository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IRepository<User> repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(UserRegisterDto dto)
    {
        var passwordHash = _passwordHasher.HashPassword(dto.Password);

        var user = UserMapper.ToEntity(dto, passwordHash);
        user.SetPasswordHash(passwordHash);

        await _repository.AddAsync(user);
    }
}
