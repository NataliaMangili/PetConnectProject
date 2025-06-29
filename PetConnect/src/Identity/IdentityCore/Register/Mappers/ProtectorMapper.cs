using IdentityCore.Domain.Entities;
using IdentityCore.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Register.Mappers;
public static class ProtectorMapper
{
    public static Protector ToEntity(ProtectorRegisterDto dto, string passwordHash)
    {
        var protector = new Protector(dto.Email, dto.FullName);
        protector.SetPasswordHash(passwordHash);
        return protector;
    }
}
