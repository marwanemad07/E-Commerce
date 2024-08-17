using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{shippingMethodId}")]
        public async Task<ActionResult<RestDto<OrderDto>>> CreateOrder(int shippingMethodId)
        {
            try
            {
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (customerId != null)
                {
                    var restDto = await _orderService.CreateOrderAsync(customerId, shippingMethodId);
                    if (restDto.StatusCode == 400)
                    {
                        return BadRequest(new ApiResponse(400, "Order wasn't created"));
                    }
                    else if (restDto.StatusCode == 404)
                    {
                        return NotFound(new ApiResponse(404, "Cart is empty"));
                    }
                    return Ok(restDto);
                }
                return BadRequest(new ApiResponse(400, "Token hasn't an email"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(500, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestDto<OrderDto?>>> GetOrderById(int id)
        {
            var restDto = await _orderService.GetOrderByIdAsync(id);
            if (restDto.StatusCode == 404)
            {
                return NotFound(new ApiResponse(404, "Order not found"));
            }
            return Ok(restDto);
        }

        // this API should be available only for admin but for now it's available for all users
        [HttpGet]
        public async Task<ActionResult<RestDto<List<OrderDto>>?>> GetOrderes()
        {
            try
            {
                var restDto = await _orderService.GetOrdersAsync();
                return Ok(restDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(500, ex.Message));
            }
        }

        [HttpPut("{orderId}/{newStatus}")]
        public async Task<ActionResult<RestDto<OrderDto?>>> UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                var restDto = await _orderService.UpdateOrderStatus(orderId, newStatus);
                if (restDto.StatusCode == 404)
                {
                    return NotFound(new ApiResponse(404, "Order not found"));
                }
                else if (restDto.StatusCode == 400)
                {
                    return BadRequest(new ApiResponse(400, "Invalid order status"));
                }
                return Ok(restDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(500, ex.Message));
            }
        }
    }
}
