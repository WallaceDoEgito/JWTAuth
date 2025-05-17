using BarotraumaJWT.Data;
using BarotraumaJWT.DTOs;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace BarotraumaJWT.Services;

public class AuthService(AppDbContext dbContext, ITokenManager tokenService, IPasswordHasher passwordHasher) : IAuthService
{

    public async Task<User?> RegisterAsync(UserRequestAuth requestAuth)
    {
        var existente = dbContext.Users.Any(x => x.LoginName == requestAuth.LoginName);
        if (existente) return null;
        User toInsert = new User(requestAuth.LoginName, requestAuth.Password);
        await dbContext.Users.AddAsync(toInsert);
        await dbContext.SaveChangesAsync();
        return toInsert;
    }

    public string? LoginAsync(UserRequestAuth requestAuth)
    {
        User? finded = dbContext.Users.SingleOrDefault(x => x.LoginName == requestAuth.LoginName);
        
        if (finded == null) return null;
        if (!passwordHasher.VerifyHash(requestAuth.Password, finded.Password)) return null;

        return tokenService.CreateToken(finded);
    }
}