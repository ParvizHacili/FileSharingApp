using FileSharingApp.Business.Abstract;
using FileSharingApp.Business.Concrete;
using FileSharingApp.Data.Abstract;
using FileSharingApp.Data.Concrete;
using FileSharingApp.Data.Concrete.EfCore;
using FileSharingApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingApp.Web
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FileDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<FileDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accesdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".FileSharingApp.Security.Cookie"
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileService, FileManager>();

            services.AddControllersWithViews();
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
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "adminfilelist",
                    pattern: "admin/filelist",
                    defaults: new { controller = "Admin", action = "FileList" }
                    );

                endpoints.MapControllerRoute(
                    name: "admineditfile",
                    pattern: "admin/editfile/{id?}",
                    defaults: new { controller = "Admin", action = "EditFile" }
                    );

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=File}/{action=Index}/{id?}");
            });
        }
    }
}
