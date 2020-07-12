using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity.UI;
using PathfinderHomebrew.Models;
using Microsoft.Extensions.Options;

namespace PathfinderHomebrew
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<FeatDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("FeatDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<ItemDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("ItemDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<IdentityDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("IdentityDataContext");
                options.UseSqlServer(connectionString, optionsBuilders => optionsBuilders.MigrationsAssembly("PathfinderHomebrew"));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdmonOnly",
                    policy =>
                    policy.RequireClaim("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
