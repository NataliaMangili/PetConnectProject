﻿using System.ComponentModel.DataAnnotations;

namespace IdentityCore.Register.DTOs;
public class UserRegisterDto
{
    [Required] public string FullName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required, MinLength(6)] public string Password { get; set; }
}
