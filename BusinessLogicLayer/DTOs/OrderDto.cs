namespace E_Commerce.BLL.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
