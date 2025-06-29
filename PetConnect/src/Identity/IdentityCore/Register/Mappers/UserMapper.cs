using IdentityCore.Domain.Entities;
using IdentityCore.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Register.Mappers;
public static class UserMapper
{
    public static User ToEntity(UserRegisterDto dto, string passwordHash)
    {
        var user = new User(dto.FullName, dto.Email);
        user.SetPasswordHash(passwordHash);
        return user;
    }
}