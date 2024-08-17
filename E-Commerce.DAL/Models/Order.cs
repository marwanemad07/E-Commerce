namespace E_Commerce.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int ShippingMethodId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = nameof(OrderStatus.Pending);
        public AppUser Customer { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
