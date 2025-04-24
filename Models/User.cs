using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Services;

namespace BarotraumaJWT.Models;

public class User
{
    public Guid Id { get; set; }
    public String LoginName { get; set; }
    public String Password { get; set; }
    public List<Characters> CreatedCharacters { get; set; } = new List<Characters>();
    private IPasswordHasher passwordHasher = new BcryptHasher();

    public User(){}
    public User(String loginName, String password)
    {
        Id = Guid.NewGuid();
        LoginName = loginName;
        Password = passwordHasher.HashPassword(password);
    }
    
}