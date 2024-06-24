namespace E_Commerce.DAL.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProdcutName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}