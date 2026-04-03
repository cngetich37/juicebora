namespace juicebora.Models;
using Microsoft.EntityFrameworkCore;

public class JuiceBoraDbContext(DbContextOptions<JuiceBoraDbContext> options) : DbContext(options)
{
    public required DbSet<Customer> Customers {get; set;}
    public required DbSet<Juice> Juices {get; set;}
    public required DbSet<Order> Orders {get; set;}

    public required DbSet<Ingredient> Ingredients {get; set;}

    public required DbSet<OrderItem> OrderItems {get; set;}

    public required DbSet<JuiceIngredient> JuiceIngredients {get; set;}
    public required DbSet<Sale> Sales {get; set;}
}
