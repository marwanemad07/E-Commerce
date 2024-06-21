namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IBrandService
    {
        public Task<List<BrandDto>> GetBrandsAsync();
    }
}
