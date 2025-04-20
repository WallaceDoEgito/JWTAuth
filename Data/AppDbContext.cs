using BarotraumaJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace BarotraumaJWT.Data;

public class AppDbContext : DbContext
{
    private DbSet<User> User;
    private DbSet<Characters> Characters;
    private DbSet<Submarine> Submarines;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;User Id=sa;Password=JRhPRt&n#xs03i*XRCja2!;Database=Barotrauma;");
    }
}