namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        public Task<List<Brand>> GetBrandsAsync();
    }
}
