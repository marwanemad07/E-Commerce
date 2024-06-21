﻿namespace E_Commerce.BLL.Services.Implemntations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if(product == null)
                return null;
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }
    }
}
