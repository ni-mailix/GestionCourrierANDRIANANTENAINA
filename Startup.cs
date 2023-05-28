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

            // Configure MVC and enable endpoint routing
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); // Optional: enables runtime compilation of Razor views

            // Add routing
            services.AddRouting(options => options.LowercaseUrls = true);
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "courrier-create",
                    pattern: "courrier/create",
                    defaults: new { controller = "Courrier", action = "CreateCourrier" }
                );

                endpoints.MapControllerRoute(
                    name: "courrier-details",
                    pattern: "courrier/{id}",
                    defaults: new { controller = "Courrier", action = "Details" }
                );

                endpoints.MapControllerRoute(
                    name: "courrier-query",
                    pattern: "courrier/query",
                    defaults: new { controller = "Courrier", action = "Query" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
