namespace BarotraumaJWT.Models;

public class User
{
    public Guid Id { get;}
    public String Name { get; set; }
    public String Password { get; set; }
    public List<Characters> CreatedCharacters { get; set; }
    
}