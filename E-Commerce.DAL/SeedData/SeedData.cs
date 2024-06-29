using System.Text.Json.Serialization;

namespace E_Commerce.DAL.SeedData
{
    public class SeedData
    {
        public static async void SeedProducts(AppDbContext context)
        {
            try
            {
                var seedDataPath = GetDatapath();
                if (!context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText(seedDataPath + "/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                    await context.Database.BeginTransactionAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories ON");
                    context.Categories.AddRange(categories);
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories OFF");
                    await context.Database.CommitTransactionAsync();
                }

                if (!context.Brands.Any())
                {
                    var brandsData = File.ReadAllText(seedDataPath + "/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);

                    await context.Database.BeginTransactionAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Brands ON");
                    context.Brands.AddRange(brands);
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Brands OFF");
                    await context.Database.CommitTransactionAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(seedDataPath + "/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // this should be logged
            }
        }

        public static async void SeedUsers(UserManager<AppUser> userManager)
        {
            var seedDataPath = GetDatapath();
            try
            {
                if(!userManager.Users.Any())
                {
                    var usersData = File.ReadAllText(seedDataPath + "/users.json");
                    var users = JsonSerializer.Deserialize<List<UserData>>(usersData);
                    // map users to AppUser (I may use auto mapper here 
                    // but i just need it here now, so i'm gonna do it manually)
                    if (users != null)
                    {
                        foreach (var user in users)
                        {
                            var AppUser = MapAppUser(user);
                            await userManager.CreateAsync(AppUser, user.Password);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // this should be logged
            }

        }

        private static AppUser MapAppUser(UserData user)
        {
            return new AppUser
            {
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                City = user.City,
                Region = user.Region,
                ZipCode = user.ZipCode,
            };
        }

        private static string? GetDatapath()
        {
            try
            {
                var basePath = Directory.GetCurrentDirectory();
                var solutionRoot = Directory.GetParent(basePath).FullName;
                return Path.Combine(solutionRoot, "E-Commerce.DAL", "seeddata");
            } 
            catch
            {
                throw;
            }
        }
    }

    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
