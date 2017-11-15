using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using IrmaProject.Repository.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.ApplicationService;
using Microsoft.AspNetCore.Rewrite;
using IrmaProject.Repository.EntityFramework.Interfaces;
using IrmaProject.Repository.EntityFramework.Repositories;
using IrmaProject.Repository.AzureStorage.Interfaces;
using IrmaProject.Repository.AzureStorage.Repositories;

namespace IrmaProject
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
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    o.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
                })
                .AddFacebook(o =>
                {
                    o.AppId = Configuration["Authentication:Facebook:AppId"];
                    o.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    o.Scope.Add("email");
                    o.Fields.Add("name");
                    o.Fields.Add("email");
                    o.SaveTokens = true;
                });

            services.AddMvc();
            services.AddDbContext<PicBookDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), migration => migration.MigrationsAssembly("IrmaProject"));
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAzureStorageImageRepository>(imageRepo => new AzureStorageImageRepository(Configuration["AzureStorage:ConnectionString"]));
            services.AddScoped<IDbImageRepository, DbImageRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var options = new RewriteOptions().AddRedirectToHttps(301, 44356);
            app.UseRewriter(options);
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
