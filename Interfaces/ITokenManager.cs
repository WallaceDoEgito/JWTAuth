using BarotraumaJWT.Models;

namespace BarotraumaJWT.Interfaces;

public interface ITokenManager
{
    public String CreateToken(User user);
    public String RefreshToken(String refreshToken);
}