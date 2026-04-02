namespace juicebora.models;
using Microsoft.EntityFrameworkCore;

public class JuiceDbContext(DbContextOptions<JuiceDbContext> options) : DbContext(options)
{
    public DbSet<Juice> Juices {get; set;}
}