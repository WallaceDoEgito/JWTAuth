using BarotraumaJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace BarotraumaJWT.Data;

public class AppDbContext : DbContext
{
    public DbSet<Characters> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Submarine> Submarines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;User Id=sa;Password=JRhPRt&n#xs03i*XRCja2!;Database=Barotrauma;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.CreatedCharacters).WithOne().HasForeignKey("CreatorId").OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Characters>().Property(c => c.Profission).HasConversion<String>();
        base.OnModelCreating(modelBuilder);
        
    }
}