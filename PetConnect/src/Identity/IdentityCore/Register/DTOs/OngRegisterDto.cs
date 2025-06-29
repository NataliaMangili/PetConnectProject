using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCore.Register.DTOs;

public class OngRegisterDto
{
    [Required] public string OrganizationName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string CNPJ { get; set; }
    [Required] public string Phone { get; set; }
    [Required] public string ResponsiblePerson { get; set; }
    [Required] public string Address { get; set; }
    [Required, MinLength(6)] public string Password { get; set; }
}
