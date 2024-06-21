namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
