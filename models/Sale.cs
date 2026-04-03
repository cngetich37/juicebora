using Microsoft.EntityFrameworkCore;

namespace juicebora.Models;

public class Sale
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public DateTime SaleDate { get; set; }
    [Precision(18, 2)]
    public decimal AmountPaid { get; set; }
    public string? PaymentMethod { get; set; }
}