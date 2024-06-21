
using Microsoft.Extensions.Configuration;

namespace E_Commerce.BLL.Helpers
{
    public class ProductImageResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _confg;

        public ProductImageResolver(IConfiguration confg)
        {
            _confg = confg;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.Image))
            {
                return $"{_confg["ApiUrl"]}{source.Image}";
            }
            return null; // here you can return a default image url instead of null
        }
    }
}
