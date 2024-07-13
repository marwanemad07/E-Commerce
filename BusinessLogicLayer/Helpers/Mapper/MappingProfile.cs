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
        }
    }
}
