using BarotraumaJWT.Enums;

namespace BarotraumaJWT.Models;

public class Characters
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Roles Profission { get; private set; }

    public Characters(String name, Roles profission)
    {
        Id = Guid.NewGuid();
        Name = name;
        Profission = profission;
    }
}