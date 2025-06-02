using IdentityCore.Domain.Entities.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public UserType UserType { get; set; }
    public string? CNPJ { get; set; }
    public string? CPF { get; set; }
    public DateTime CreatedAt { get; set; }
}
