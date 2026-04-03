using Microsoft.EntityFrameworkCore;
namespace juicebora.Models;

public class JuiceBoraDbContext(DbContextOptions<JuiceBoraDbContext> options) : DbContext(options)
{
    public DbSet<Juice> Juices { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<JuiceIngredient> JuiceIngredients { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Sale)
            .WithOne(s => s.Order)
            .HasForeignKey<Sale>(s => s.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Juice)
            .WithMany(j => j.OrderItems)
            .HasForeignKey(oi => oi.JuiceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JuiceIngredient>()
            .HasOne(ji => ji.Juice)
            .WithMany(j => j.JuiceIngredients)
            .HasForeignKey(ji => ji.JuiceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JuiceIngredient>()
            .HasOne(ji => ji.Ingredient)
            .WithMany(i => i.JuiceIngredients)
            .HasForeignKey(ji => ji.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Juice>()
            .HasMany(j => j.JuiceIngredients)
            .WithOne(ji => ji.Juice)
            .HasForeignKey(ji => ji.JuiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
