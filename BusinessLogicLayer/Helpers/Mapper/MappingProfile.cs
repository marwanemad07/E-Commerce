namespace E_Commerce.BLL.Helpers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(p => p.BrandName, opt => opt.MapFrom(p => p.Brand.Name))
                .ForMember(p => p.Image, opt => opt.MapFrom<ProductImageResolver>());

            CreateMap<AppUser, UserDto>()
                .ForMember(u => u.Token, opt => opt.MapFrom<JwtTokenResolver>());
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserProfileDto>();
            CreateMap<UserProfileDto, AppUser>();

            CreateMap<CustomerCart, Order>()
                .ForMember(o => o.Id, opt => opt.Ignore())
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(opt => opt.Items.Sum(oi => oi.Price * oi.Quantity)))
                .ForMember(o => o.OrderItems, c => c.MapFrom<CartItemsToOrderItemsResolver>());

            CreateMap<Order, OrderDto>()
                .ForMember(d => d.OrderItems, opt => opt.MapFrom<OrderItemToDtoResolver>())
                .ForMember(d => d.ShippingMethod, opt => opt.MapFrom(o => o.ShippingMethod.Name));
        }
    }
}
