namespace E_Commerce.BLL.Helpers.Mapper.MapResolver
{
    public class CartItemsToOrderItemsResolver : IValueResolver<CustomerCart, Order, List<OrderItem>>
    {
        public List<OrderItem> Resolve(CustomerCart source, Order destination, List<OrderItem> destMember, ResolutionContext context)
        {
            return source.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.Price
            }).ToList();
        }
    }
}
