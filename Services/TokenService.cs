using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.IdentityModel.Tokens;

namespace BarotraumaJWT.Services;

public class TokenService(IConfiguration configuration) : ITokenManager
{
    public string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.LoginName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWTConfig:SecretKey")!));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken
            (
                issuer: configuration.GetValue<String>("JWTConfig:Issuer"),
                audience:configuration.GetValue<String>("JWTConfig:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(configuration.GetValue<Double>("JWTConfig:ExpirationInMin")),
                signingCredentials: cred
            );
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public string RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }
}