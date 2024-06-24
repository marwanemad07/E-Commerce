namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;
        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCart(string id)
        {
            var cart = await _cartRepo.GetCartAsync(id);
            cart ??= await _cartRepo.UpdateCartAsync(new CustomerCart(id));
            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCart>> UpdateCart(CustomerCart customerCart)
        {
            var updatedCart = await _cartRepo.UpdateCartAsync(customerCart);
            return Ok(updatedCart);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCart(string id)
        {
            var deleted = await _cartRepo.DeleteCartAsync(id);
            return deleted ? NoContent() : NotFound(new ApiResponse(404));
        }
    }
}
