namespace E_Commerce.BLL.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(AppUser user);
    }
}
