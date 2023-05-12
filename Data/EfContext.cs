using Microsoft.EntityFrameworkCore;
using RunningApp.ApplicationCore;

namespace RunningApp.Data;

public class EfContex : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RunningInfo> RunningInfos { get; set; }
    public DbSet<RunningPointInfo> RunningPointInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source = {"database.db"}");
    }
}