using E_Commerce.BLL.Helpers.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSettings(builder.Configuration);

builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterRedisCache(builder.Configuration);

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.RegisterHelpers();

builder.Services.ConfigureAuthentication();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddLogging();

builder.Services.ConfigureApiValidationErrorResponse();

builder.Services.AddNeededCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/error/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    SeedData.SeedProducts(context);
    SeedData.SeedUsers(userManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while seeding the database.");
}

app.Run();
