
namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class ShippingMethodsRepository : IShippingMethodsRepository
    {
        private readonly AppDbContext _context;

        public ShippingMethodsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ShippingMethod?> GetShippingMethodByIdAsync(int id)
        {
            return await _context.ShippingMethods
                .AsNoTracking()
                .FirstOrDefaultAsync(sm => sm.Id == id);
        }

        public async Task<ShippingMethod?> GetShippingMethodByNameAsync(string name)
        {
            return await _context.ShippingMethods
                .AsNoTracking()
                .FirstOrDefaultAsync(sm => sm.Name = name);
        }

        public async Task<List<ShippingMethod>> GetShippingMethodsAsync()
        {
            return await _context.ShippingMethods
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
