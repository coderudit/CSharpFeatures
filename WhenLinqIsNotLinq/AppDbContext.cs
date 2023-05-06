using Microsoft.EntityFrameworkCore;

namespace WhenLinqIsNotLinq;

public class AppDbContext: DbContext
{
    public DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db");
}