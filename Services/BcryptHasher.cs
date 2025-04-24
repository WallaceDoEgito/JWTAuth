using BarotraumaJWT.Interfaces;
using BCrypt.Net;

namespace BarotraumaJWT.Services;

public class BcryptHasher : IPasswordHasher
{
    public string HashPassword(string originalPassword)
    {
        String hashedPassword = BCrypt.Net.BCrypt.HashPassword(originalPassword);
        return hashedPassword;
    }

    public bool VerifyHash(string originalPassword, string passwordStored)
    {
        bool isTheSame = BCrypt.Net.BCrypt.Verify(originalPassword, passwordStored);
        return isTheSame;
    }
}