using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = [];
    }
}
