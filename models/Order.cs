using Microsoft.EntityFrameworkCore;

namespace juicebora.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    [Precision(18, 2)]
    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public Sale? Sale { get; set; }
}