﻿using IdentityCore.Domain.Entities;
using IdentityCore.Login.DTOS;
using IdentityCore.Register.DTOs;
using IdentityCore.Register.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IRegistrationService<UserRegisterDto> _commonUserService;
    private readonly IRegistrationService<OngRegisterDto> _ongService;
    private readonly IRegistrationService<ProtectorRegisterDto> _protectorService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(
        IRegistrationService<UserRegisterDto> commonUserService,
        IRegistrationService<OngRegisterDto> ongService,
        IRegistrationService<ProtectorRegisterDto> protectorService,
        SignInManager<ApplicationUser> signInManager)
    {
        _commonUserService = commonUserService;
        _ongService = ongService;
        _protectorService = protectorService;
        _signInManager = signInManager;
    }

    [HttpPost("register/common")]
    public async Task<IActionResult> RegisterCommonUser([FromBody] UserRegisterDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _commonUserService.RegisterAsync(dto);
        return Ok("Usuário comum registrado com sucesso.");
    }

    [HttpPost("register/ong")]
    public async Task<IActionResult> RegisterOng([FromBody] OngRegisterDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _ongService.RegisterAsync(dto);
        return Ok("ONG registrada com sucesso.");
    }

    [HttpPost("register/protector")]
    public async Task<IActionResult> RegisterProtector([FromBody] ProtectorRegisterDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _protectorService.RegisterAsync(dto);
        return Ok("Protetor independente registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (!result.Succeeded)
            return Unauthorized("Login inválido.");

        return Ok("Login realizado com sucesso.");
    }
}
