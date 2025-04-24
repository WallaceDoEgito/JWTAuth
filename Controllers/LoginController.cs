using System.ComponentModel.DataAnnotations;
using BarotraumaJWT.Data;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Route("api")]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher _hasher;

    public LoginController(AppDbContext dbContext, IPasswordHasher hasher)
    {
        _dbContext = dbContext;
        _hasher = hasher;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Registrar(UserRequest dados)
    {
        var existente = _dbContext.Users.Any(x => x.LoginName == dados.LoginName);
        if (existente) return StatusCode(409, new {msg = "Um usuario com esse nome ja existe" });
        User toInsert = new User(dados.LoginName, dados.Password);
        await _dbContext.Users.AddAsync(toInsert);
        await _dbContext.SaveChangesAsync();
        return Ok(new {msg = "Usuario criado com sucesso!"});
    }

    [HttpPost("login")]
    public IActionResult Login(UserRequest dados)
    {
        var findUser = _dbContext.Users.First(x => x.LoginName == dados.LoginName);
        if (findUser == null) return StatusCode(404, new { msg = "O login name ou a senha esta errada" });
        if (!_hasher.VerifyHash(dados.Password, findUser.Password)) return StatusCode(404, new { msg = "O login name ou a senha esta errada" });
        return Ok();
    }
    
}

public record UserRequest(String LoginName, String Password);