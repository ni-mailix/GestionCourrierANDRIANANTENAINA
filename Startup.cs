using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonNameSpaceGestionCourrier.Data;

namespace MonNameSpaceGestionCourrier
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       public void ConfigureServices(IServiceCollection services)
{
    // Configure DbContext
    services.AddDbContext<GestionCourrierDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    // Configure MVC
    services.AddControllersWithViews();

    // Configure default routing
    services.AddMvc(options => options.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
}



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
{
    // Affichage des détails d'un courrier
    routes.MapRoute(
        name: "courrier-details",
        template: "courrier/{id}",
        defaults: new { controller = "CourrierController", action = "Details" }
    );

    // Création d'un nouveau courrier
    routes.MapRoute(
        name: "courrier-create",
        template: "courrier/create",
        defaults: new { controller = "CourrierController", action = "CreateCourrier" }
    );

    // Interrogation des courriers
    routes.MapRoute(
        name: "courrier-query",
        template: "courrier/query",
        defaults: new { controller = "CourrierController", action = "Query" }
    );

    // Autres routes...

    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}"
    );
});

        }
    }
}
