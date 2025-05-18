using BarotraumaJWT.Enums;

namespace BarotraumaJWT.Models;

public class Characters
{
    public Guid CreatorId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Roles Profission { get; set; }

    public Characters(){}
    public Characters(String name, Roles profission)
    {
        Id = Guid.NewGuid();
        Name = name;
        Profission = profission;
    }
}