using Microsoft.EntityFrameworkCore;

namespace juicebora.models;
public class Order
{
    public int Id { get; set; }
    public string? CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    [Precision(18, 2)]
    public decimal TotalAmount { get; set; }
}