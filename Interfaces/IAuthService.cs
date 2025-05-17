using BarotraumaJWT.DTOs;
using BarotraumaJWT.Models;

namespace BarotraumaJWT.Interfaces;

public interface IAuthService
{
    public Task<User?> RegisterAsync(UserRequestAuth requestAuth);
    public String? LoginAsync(UserRequestAuth requestAuth);
}