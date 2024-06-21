namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        public Task<Product?> GetProductByIdAsync(int id);
        public Task<List<Product>> GetProductsAsync();
    }
}
