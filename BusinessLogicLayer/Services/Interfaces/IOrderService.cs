namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<RestDto<OrderDto?>> CreateOrderAsync(string customerId, int shippingMethodId);
        Task<RestDto<OrderDto?>> GetOrderByIdAsync(int id);
        Task<RestDto<List<OrderDto>?>> GetOrdersForUserAsync(string userId);
        Task<RestDto<List<OrderDto>?>> GetOrdersAsync();
        Task<RestDto<OrderDto?>> UpdateOrderStatusAsync(int id, string orderStatus);
        Task<RestDto<bool>> DeleteOrderAsync(int id);
    }
}
