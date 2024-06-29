namespace E_Commerce.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(cfg.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();
        }
    }
}
