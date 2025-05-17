using BarotraumaJWT.Data;
using BarotraumaJWT.DTOs;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace BarotraumaJWT.Services;

public class AuthService(AppDbContext dbContext, ITokenManager tokenService, IPasswordHasher passwordHasher) : IAuthService
{

    public async Task<User?> RegisterAsync(UserRequest request)
    {
        var existente = dbContext.Users.Any(x => x.LoginName == request.LoginName);
        if (existente) return null;
        User toInsert = new User(request.LoginName, request.Password);
        await dbContext.Users.AddAsync(toInsert);
        await dbContext.SaveChangesAsync();
        return toInsert;
    }

    public string? LoginAsync(UserRequest request)
    {
        User? finded = dbContext.Users.SingleOrDefault(x => x.LoginName == request.LoginName);
        
        if (finded == null) return null;
        if (!passwordHasher.VerifyHash(request.Password, finded.Password)) return null;

        return tokenService.CreateToken(finded);
    }
}