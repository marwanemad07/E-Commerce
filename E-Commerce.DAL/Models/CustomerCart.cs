namespace E_Commerce.DAL.Models
{
    public class CustomerCart
    {
        public CustomerCart()
        {
            
        }
        public CustomerCart(string id)
        {
            Id = id;
        }
        public string Id { get; set; } = null!;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
