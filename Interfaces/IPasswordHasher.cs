namespace BarotraumaJWT.Interfaces;

public interface IPasswordHasher
{
    public String HashPassword(string originalPass);
    public bool VerifyHash(string originalPass, string storedPass);
}