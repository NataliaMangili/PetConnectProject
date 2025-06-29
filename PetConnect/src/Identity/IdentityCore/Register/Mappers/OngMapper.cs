using IdentityCore.Domain.Entities;
using IdentityCore.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Register.Mappers;

public static class OngMapper
{
    public static Ong ToEntity(OngRegisterDto dto, string passwordHash)
    {
        var ong = new Ong(dto.Email, dto.OrganizationName, dto.CNPJ
            //, dto.Phone, dto.ResponsiblePerson, dto.Address
            );
        ong.SetPasswordHash(passwordHash);
        return ong;
    }
}