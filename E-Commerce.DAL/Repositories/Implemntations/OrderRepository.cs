
namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> CreateOrderAsync(Order newOrder)
        {
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return await GetOrderByIdAsync(newOrder.Id);
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ShippingMethod)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ShippingMethod)
                .Include(o => o.Customer)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersForUserAsync(string customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ShippingMethod)
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> UpdateOrderStatusِAsync(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders
                                       .Include(o => o.OrderItems)
                                       .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return false;
            }

            _context.OrderItems.RemoveRange(order.OrderItems);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
