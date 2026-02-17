using Microsoft.EntityFrameworkCore;

namespace Ormconsole;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = 
            "server=localhost;port=3306;database=OrmEfDb;user=root;password=root;";

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }
}
