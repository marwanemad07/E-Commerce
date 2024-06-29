namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCart(string id)
        {
            var cart = await _cartService.GetCartAsync(id);
            cart ??= await _cartService.UpdateCartAsync(new CustomerCart(id));
            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCart>> UpdateCart(CustomerCart customerCart)
        {
            var updatedCart = await _cartService.UpdateCartAsync(customerCart);
            return Ok(updatedCart);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCart(string id)
        {
            var deleted = await _cartService.DeleteCartAsync(id);
            return deleted ? NoContent() : NotFound(new ApiResponse(404));
        }
    }
}
