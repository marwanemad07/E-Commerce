namespace E_Commerce.BLL.Helpers.Mapper.MapResolver
{
    public class OrderItemToDtoResolver : IValueResolver<Order, OrderDto, List<OrderItemDto>>
    {
        public List<OrderItemDto> Resolve(Order source, OrderDto destination, List<OrderItemDto> destMember, ResolutionContext context)
        {
            return source.OrderItems.Select(o => new OrderItemDto
            {
                Id = o.Id,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice
            }
            ).ToList();
        }
    }
}
