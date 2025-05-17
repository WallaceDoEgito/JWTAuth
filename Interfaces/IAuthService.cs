using BarotraumaJWT.DTOs;
using BarotraumaJWT.Models;

namespace BarotraumaJWT.Interfaces;

public interface IAuthService
{
    public Task<User?> RegisterAsync(UserRequest request);
    public String? LoginAsync(UserRequest request);
}