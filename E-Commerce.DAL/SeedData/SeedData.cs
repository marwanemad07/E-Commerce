namespace E_Commerce.DAL.SeedData
{
    public class SeedData
    {
        public static async void Seed(AppDbContext context)
        {
            try
            {
                var basePath = Directory.GetCurrentDirectory();
                var solutionRoot = Directory.GetParent(basePath).FullName;
                var seedDataPath = Path.Combine(solutionRoot, "E-Commerce.DAL", "seeddata");
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
    }
}
