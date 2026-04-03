namespace juicebora.Models;
using Microsoft.EntityFrameworkCore;
public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public int JuiceId { get; set; }
    [Precision(18, 2)]
    public decimal UnitPrice { get; set; }

    
}