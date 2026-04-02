using Microsoft.EntityFrameworkCore;

namespace juicebora.models;

    public class Juice
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
