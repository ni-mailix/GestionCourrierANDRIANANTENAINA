using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonNameSpaceGestionCourrier.Data;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GestionCourrierDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
           sqlOptions.EnableRetryOnFailure();
       }
        ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Get an instance of the DbContext from the service provider
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<GestionCourrierDbContext>();

    try
    {
        // Apply any pending migrations to the database
        dbContext.Database.Migrate();

        // Your additional database-related code here...

        // The application will continue running after this point
    }
    catch (Exception ex)
    {
        // Handle any errors that occurred during database initialization
        // You can log the exception or take appropriate action
        Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
    }
}

app.Run();
