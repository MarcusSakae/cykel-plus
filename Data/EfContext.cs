using Microsoft.EntityFrameworkCore;
using RunningApp.ApplicationCore;

namespace RunningApp.Data;

public class EfContex : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source = {"database.db"}");
    }
}