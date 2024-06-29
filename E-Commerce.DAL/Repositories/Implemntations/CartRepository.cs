using StackExchange.Redis;

namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;
        
        public CartRepository(IConnectionMultiplexer mux)
        {
            _database = mux.GetDatabase();
        }

        public async Task<CustomerCart?> GetCartAsync(string customerId)
        {
            var cart = await _database.StringGetAsync(customerId);
            return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerCart>(cart!);

        }

        public async Task<bool> UpdateCartAsync(CustomerCart customerCart)
        {
            var updated = await _database.StringSetAsync(customerCart.Id,
                JsonSerializer.Serialize(customerCart), TimeSpan.FromDays(30));
            return updated;
        }

        public async Task<bool> DeleteCartAsync(string customerId)
        {
            return await _database.KeyDeleteAsync(customerId);
        }
    }
}
