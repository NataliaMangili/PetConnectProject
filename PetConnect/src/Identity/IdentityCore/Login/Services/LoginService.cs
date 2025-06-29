using IdentityCore.Domain;
using IdentityCore.Domain.Entities;
using IdentityCore.Login.DTOS;
using IdentityCore.Login.Interfaces;
using IdentityCore.Register.DTOs;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Login.Services;
public class LoginService : ILoginService<LoginDto>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
            throw new UnauthorizedAccessException("Usuário não encontrado.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Credenciais inválidas.");

    }
}
