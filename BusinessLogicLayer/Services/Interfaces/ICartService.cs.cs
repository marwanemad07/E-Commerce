namespace E_Commerce.BLL.Services.Interfaces
{
    public interface ICartService
    {
        public Task<CustomerCart?> GetCartAsync(string customerId);
        public Task<CustomerCart?> UpdateCartAsync(CustomerCart customerCart);
        public Task<bool> DeleteCartAsync(string customerId);
    }
}
