
using E_Commerce.DAL.Models.Identity;

namespace E_Commerce.BLL.Helpers
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

            CreateMap<AppUser, UserDto>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
