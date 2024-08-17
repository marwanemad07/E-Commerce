
namespace E_Commerce.BLL.Services.Implemntations
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IShippingMethodsRepository _shippingMethodsRepository;
        private readonly IMapper _mapper;

        public OrderService(ICartRepository cartRepository,
            IOrderRepository orderRepository,
            IShippingMethodsRepository shippingMethodsRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _shippingMethodsRepository = shippingMethodsRepository;
            _mapper = mapper;
        }

        public async Task<RestDto<OrderDto?>> CreateOrderAsync(string customerId, int shippingMethodId)
        {
            var cart = await _cartRepository.GetCartAsync(customerId);
            var shippingMethod = await _shippingMethodsRepository.GetShippingMethodByIdAsync(shippingMethodId);
            if(cart == null || cart.Items.Count == 0 || shippingMethod == null)
            {
                return RestHelper.CreateResponse<OrderDto>(null, 404);
            }

            var order = GetOrderFromCart(cart, customerId, shippingMethod);

            var result = await _orderRepository.CreateOrderAsync(order);
            if(result == null)
            {
                return RestHelper.CreateResponse<OrderDto>(null, 400);
            }
            await _cartRepository.DeleteCartAsync(customerId);
            return RestHelper.CreateResponse(_mapper.Map<Order, OrderDto>(result), 200);
        }

        public async Task<RestDto<OrderDto?>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if(order == null)
            {
                return RestHelper.CreateResponse<OrderDto>(null, 404);
            }
            return RestHelper.CreateResponse(_mapper.Map<Order, OrderDto>(order), 200);
        }

        public async Task<RestDto<List<OrderDto>?>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return GetRestOrders(orders);
        }

        public async Task<RestDto<List<OrderDto>?>> GetOrdersForUserAsync(string userId)
        {
            var orders = await _orderRepository.GetOrdersForUserAsync(userId);
            return GetRestOrders(orders);
        }

        public async Task<RestDto<OrderDto?>> UpdateOrderStatusAsync(int id, string orderStatus)
        {
            if(!Enum.TryParse<OrderStatus>(orderStatus, true, out var status))
            {
                return RestHelper.CreateResponse<OrderDto>(null, 400);
            }
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if(order == null)
            {
                return RestHelper.CreateResponse<OrderDto>(null, 404);
            }
            order.Status = nameof(status);
            var result = await _orderRepository.UpdateOrderStatusِAsync(order);
            if(result == 0)
            {
                return RestHelper.CreateResponse<OrderDto>(null, 400);
            }
            return RestHelper.CreateResponse(_mapper.Map<Order, OrderDto>(order), 200);

        }

        public async Task<RestDto<bool>> DeleteOrderAsync(int id)
        {
            var result = await _orderRepository.DeleteOrderAsync(id);
            int code = result ? 200 : 404;
            return RestHelper.CreateResponse(result, code);
        }


        private Order? GetOrderFromCart(CustomerCart cart, string customerId, ShippingMethod shippingMethod)
        {
            var order = _mapper.Map<CustomerCart, Order>(cart);
            order.CustomerId = customerId;
            order.ShippingMethodId = shippingMethod.Id;
            order.TotalPrice += shippingMethod.Price;
            return order;
        }

        private RestDto<List<OrderDto>?> GetRestOrders(List<Order> orders)
        {
            var restDto = new RestDto<List<OrderDto>>();
            if (orders == null || orders.Count == 0)
            {
                return RestHelper.CreateResponse<List<OrderDto>>(null ,404);
            }
            return RestHelper.CreateResponse(
                orders.Select(o => _mapper.Map<Order, OrderDto>(o)).ToList(),
                    200);
        }
    }
}
