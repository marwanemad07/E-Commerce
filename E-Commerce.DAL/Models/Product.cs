using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(400)]
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
