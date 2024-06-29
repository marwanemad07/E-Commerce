namespace E_Commerce.DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<AppUser?> GetUserByIdAsync(string userId);
        public Task<AppUser?> GetUserByEmailAsync(string email);
        public Task<AppUser?> GetUserByUsernameAsync(string username);
        public Task<bool> CheckPasswordAsync(AppUser user, string password);
        public Task<IdentityResult> CreateUserAsync(AppUser newUser, string password);
        public Task<SignInResult> SignInAsync(AppUser user, string password);
    }
}
