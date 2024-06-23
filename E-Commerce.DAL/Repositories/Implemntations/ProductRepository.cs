namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Product> GetProducts(int? categoryId, int? brandId)
        {
            var query = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .AsQueryable();

            if(categoryId != null)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if(brandId != null)
            {
                query = query.Where(p => p.BrandId == brandId);
            }

            return query;
        }

        public IQueryable<Product> ApplyPagination(IQueryable<Product> query, int pageNumber, int pageSize)
        {
            return query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).AsQueryable();
        }

        public IQueryable<Product> ApplySearch(IQueryable<Product> query, string search)
        {
            return query.Where(p => p.Name.ToLower().Contains(search)).AsQueryable();
        }

        public IQueryable<Product> ApplySort(IQueryable<Product> query, string sort)
        {
            return sort switch
            {
                "priceAsc" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query
            };
        }

    }
}
