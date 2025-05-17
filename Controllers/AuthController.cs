using System.ComponentModel.DataAnnotations;
using BarotraumaJWT.Data;
using BarotraumaJWT.DTOs;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Registrar(UserRequest dados)
    {
        User? res = await authService.RegisterAsync(dados);
        if (res == null) return BadRequest("Este usuario ja existe");
        return StatusCode(StatusCodes.Status201Created, new { id = res.Id });
    }

    [HttpPost("login")]
    public IActionResult Login(UserRequest dados)
    {
        String? token = authService.LoginAsync(dados);
        if (token == null) return BadRequest("O Usuario ou a senha está errado");
        return Ok(token);
    }
    
}