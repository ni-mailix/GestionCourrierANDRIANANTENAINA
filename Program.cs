using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonNameSpaceGestionCourrier.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure les services
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GestionCourrierDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        }));

var app = builder.Build();

// Configure le pipeline de requête HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Initialise la base de données
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<GestionCourrierDbContext>();
    var hostEnvironment = services.GetRequiredService<IWebHostEnvironment>();

    // Applique les migrations pendantes à la base de données
    if (hostEnvironment.IsDevelopment())
    {
        dbContext.Database.Migrate();
    }

    // Votre code supplémentaire lié à la base de données ici...
}

app.Run();
