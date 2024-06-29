
namespace E_Commerce.DAL.Repositories.Implemntations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser newUser, string password)
        {
            return await _userManager.CreateAsync(newUser, password);
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            return await GetUserByEmailAsync(username);
        }
        public async Task<SignInResult> SignInAsync(AppUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}
