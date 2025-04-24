using BarotraumaJWT.Enums;

namespace BarotraumaJWT.Models;

public class Submarine
{
    public Guid Id { get; private set; }
    public SubmarineModels Model { get; set; }
    public List<Characters> Tripulates { get; set; } = new List<Characters>();
}