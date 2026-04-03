using Microsoft.EntityFrameworkCore;

namespace juicebora.Models;

public class JuiceIngredient
{
    public int Id { get; set; }
    public int JuiceId { get; set; }

    public int IngredientId { get; set; }

    [Precision(18, 2)]
    public decimal QuantityRequired { get; set; }
}