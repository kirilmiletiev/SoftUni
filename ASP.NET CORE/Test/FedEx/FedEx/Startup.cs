using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FedEx.Data;
using FedEx.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FedEx
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<FedExUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(optinons =>
            {
                optinons.SignIn.RequireConfirmedEmail = false;
                optinons.Password.RequiredLength = 3;
                optinons.Password.RequireLowercase = false;
                optinons.Password.RequireNonAlphanumeric = false;
                optinons.Password.RequireLowercase = false;
                optinons.Password.RequireUppercase = false;
                optinons.Password.RequiredUniqueChars = 0;
            });


            services.AddIdentity<FedExUser, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<UserManager<FedExUser>, UserManager<FedExUser>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FedEx.Data;
//using FedEx.Data.Models;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace FedEx
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                options.CheckConsentNeeded = context => true;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });

//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(
//                    Configuration.GetConnectionString("DefaultConnection")));

//            //services.AddDefaultIdentity<IdentityUser>()
//            //    .AddEntityFrameworkStores<ApplicationDbContext>();
//            //------
//            services.Configure<IdentityOptions>(optinons =>
//            {
//                optinons.SignIn.RequireConfirmedEmail = false;
//                optinons.Password.RequiredLength = 3;
//                optinons.Password.RequireLowercase = false;
//                optinons.Password.RequireNonAlphanumeric = false;
//                optinons.Password.RequireLowercase = false;
//                optinons.Password.RequireUppercase = false;
//                optinons.Password.RequiredUniqueChars = 0;
//            });

//            services.AddIdentity<FedExUser, IdentityRole>()
//                .AddDefaultUI()
//                .AddDefaultTokenProviders()
//                .AddEntityFrameworkStores<ApplicationDbContext>();

//            services.AddScoped<UserManager<FedExUser>, UserManager<FedExUser>>();

//            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseDatabaseErrorPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseCookiePolicy();

//            app.UseAuthentication();

//            app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "default",
//                    template: "{controller=Home}/{action=Index}/{id?}");
//            });
//        }
//    }
//}
