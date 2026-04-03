namespace juicebora.models;
using Microsoft.EntityFrameworkCore;

public class JuiceBoraDbContext(DbContextOptions<JuiceBoraDbContext> options) : DbContext(options)
{
    public required DbSet<Customer> Customers {get; set;}
    public required DbSet<Juice> Juices {get; set;}
}