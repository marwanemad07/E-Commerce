namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;
        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
