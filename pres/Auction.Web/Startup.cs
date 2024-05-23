using Auction.Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Auction.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var filePath = Configuration.GetSection("ExcelFilePath").Value;
            services.AddControllersWithViews();
            services.AddTransient<IAuthServise, AuthServise>();
            services.AddTransient<IAkkRepos, AkkRepos>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddTransient<ExcelService>(_ => new ExcelService(filePath));
            services.AddSingleton<ISlotRepos, SlotRepos>();
            services.AddTransient<IAuthServise, AuthServise>();
            services.AddTransient<IAkkRepos, AkkRepos>();
            services.AddSingleton<SlotServes>();
            services.AddTransient<IAuthServise, AuthServise>();
            services.AddControllersWithViews();
            services.AddSingleton<IAuthServise, AuthServise>();
            services.AddControllers();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
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
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search/{query?}",
                    defaults: new { controller = "Search", action = "Index" });
            });
        }
    }
}
