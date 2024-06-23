namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        public Task<Product?> GetProductByIdAsync(int id);
        public IQueryable<Product> GetProducts(int? categoryId, int? brandId);
        public IQueryable<Product> ApplySearch(IQueryable<Product> query, string search);
        public IQueryable<Product> ApplySort(IQueryable<Product> query, string sort);
        public IQueryable<Product> ApplyPagination(IQueryable<Product> query, int pageNumber, int pageSize);
    }
}
