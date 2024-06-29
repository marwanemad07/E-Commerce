namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task<CustomerCart?> GetCartAsync(string customerId);
        public Task<bool> UpdateCartAsync(CustomerCart customerCart);
        public Task<bool> DeleteCartAsync(string customerId);
    }
}
