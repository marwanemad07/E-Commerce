namespace E_Commerce.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
