using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Customizations.Identity;
using KampusStudioProto.Models.Entities;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KampusStudioProto
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                             #if DEBUG
                             .AddRazorRuntimeCompilation()
                             #endif
                             ;

            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredUniqueChars = 4;
            })
            .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<MyDbContext>();

            //services.AddTransient<IComuneService, AdoNetComuneService>();
            services.AddTransient<IComuneService, EfCoreComuneService>();
            services.AddTransient<IProvinciaService, AdoNetProvinciaService>();
            services.AddTransient<IRegioneService, AdoNetRegioneService>();
            services.AddTransient<INazioneService, AdoNetNazioneService>();
            services.AddTransient<IDatabaseAccessor, MySqlDatabaseAccessor>();
            services.AddDbContextPool<MyDbContext>(optionsBuilder =>
            {
                string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.17-mysql"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(routeBuider => {
                routeBuider.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuider.MapRazorPages();
            });
            /*
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            */
        }
    }
}
