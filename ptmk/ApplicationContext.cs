using Microsoft.EntityFrameworkCore;
using ptmk;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=;database=ptmk;AllowLoadLocalInfile=true;",
            new MySqlServerVersion(new Version(8, 0, 25)));
    }
}