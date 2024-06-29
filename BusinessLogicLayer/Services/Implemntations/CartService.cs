namespace E_Commerce.BLL.Services.Implemntations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<bool> DeleteCartAsync(string customerId)
        {
            var deleted = await _cartRepository.DeleteCartAsync(customerId);
            return deleted;
        }

        public async Task<CustomerCart?> GetCartAsync(string customerId)
        {
            var cart = await _cartRepository.GetCartAsync(customerId);
            return cart;
        }

        public async Task<CustomerCart?> UpdateCartAsync(CustomerCart customerCart)
        {
            await _cartRepository.UpdateCartAsync(customerCart);
            return await _cartRepository.GetCartAsync(customerCart.Id);
        }
    }
}
