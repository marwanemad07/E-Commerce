namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCart()
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(id == null) 
                return BadRequest(new ApiResponse(400, "Token hasn't a name identifier"));
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
        public async Task<ActionResult<bool>> DeleteCart()
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
                return BadRequest(new ApiResponse(400, "Token hasn't a name identifier"));
            var deleted = await _cartService.DeleteCartAsync(id);
            return deleted ? NoContent() : NotFound(new ApiResponse(404));
        }
    }
}
