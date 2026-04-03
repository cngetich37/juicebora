namespace juicebora.Models;
using Microsoft.EntityFrameworkCore;

public class Ingredient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Unit { get; set; }

    [Precision(18, 2)]
    public decimal QuantityInStock { get; set; }

    [Precision(18, 2)]
    public decimal ReorderLevel { get; set; }

    public ICollection<JuiceIngredient> JuiceIngredients { get; set; } = [];
}