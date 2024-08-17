namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> CreateOrderAsync(Order newOrder);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersForUserAsync(string customerId);
        Task<List<Order>> GetOrdersAsync();
        Task<int> UpdateOrderStatusِAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
