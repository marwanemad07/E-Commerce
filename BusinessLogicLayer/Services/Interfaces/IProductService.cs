namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetProductsAsync();
        public Task<ProductDto?> GetProductByIdAsync(int id);
    }
}
