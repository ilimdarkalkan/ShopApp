using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EfCore;
using Business.Abstract;
using Business.Concrete;
using ShopApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using ShopApp.WebUI.EmailServices;
using Microsoft.Extensions.Configuration;

namespace ShopApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // appsettings i�erisindeki bilgilere ula�mak i�in
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {

                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(360);

                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
            new SmtpEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:Username"],
                _configuration["EmailSender:Password"]
           ));


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "adminroles",
                  pattern: "admin/role/list",
                  defaults: new { controller = "Admin", action = "RoleList" }
                  );

                endpoints.MapControllerRoute(
                 name: "adminrolecreate",
                 pattern: "admin/role/create",
                 defaults: new { controller = "Admin", action = "RoleCreate" }
                 );

                endpoints.MapControllerRoute(
               name: "adminroleedit",
               pattern: "admin/role/{id?}",
               defaults: new { controller = "Admin", action = "RoleEdit" }
               );

                endpoints.MapControllerRoute(
                  name: "adminproducts",
                  pattern: "admin/products",
                  defaults: new { controller = "Admin", action = "ProductList" }
                  );


                endpoints.MapControllerRoute(
              name: "adminproductcreate",
              pattern: "admin/products/create",
              defaults: new { controller = "Admin", action = "ProductCreate" }
              );

                endpoints.MapControllerRoute(
                 name: "adminproductedit",
                 pattern: "admin/products/{id?}",
                 defaults: new { controller = "Admin", action = "ProductEdit" }
                 );

                endpoints.MapControllerRoute(
                 name: "admincategories",
                 pattern: "admin/categories",
                 defaults: new { controller = "Admin", action = "CategoryList" }
                 );

                endpoints.MapControllerRoute(
                name: "admincategorycreate",
                pattern: "admin/categories/create",
                defaults: new { controller = "Admin", action = "CategoryCreate" }
                );



                endpoints.MapControllerRoute(
                   name: "search",
                   pattern: "{search}",
                   defaults: new { controller = "Shop", action = "search" }
                   );

                endpoints.MapControllerRoute(
                   name: "productsdetails",
                   pattern: "{url}",
                   defaults: new { controller = "Shop", action = "details" }
                   );

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new { controller = "Shop", action = "list" }
                    );
                endpoints.MapControllerRoute(
                name: "admincategoryedit",
                pattern: "admin/categories/{id?}",
                defaults: new { controller = "Admin", action = "CategoryEdit" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
