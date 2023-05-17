using Microsoft.EntityFrameworkCore;
using WebApp.Database.Configuration;
using WebApp.Database.Entities;

namespace WebApp.Database;

public class UsersContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .UseNpgsql("Host=localhost;Database=dotnetters;Username=postgres;Password=XXXX")
        .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder
       .ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
}
