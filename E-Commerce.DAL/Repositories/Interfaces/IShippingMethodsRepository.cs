namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IShippingMethodsRepository
    {
        Task<ShippingMethod?> GetShippingMethodByIdAsync(int id);
        Task<ShippingMethod?> GetShippingMethodByNameAsync(string name);
        Task<List<ShippingMethod>> GetShippingMethodsAsync();
    }
}
