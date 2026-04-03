using Microsoft.EntityFrameworkCore;

namespace juicebora.Models;
public class Order
{
    public int Id { get; set; }
    public string? CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    [Precision(18, 2)]
    public decimal TotalAmount { get; set; }
}