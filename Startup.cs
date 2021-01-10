using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KampusStudioProto
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                             #if DEBUG
                             .AddRazorRuntimeCompilation()
                             #endif
                             ;

            //services.AddTransient<IComuneService, AdoNetComuneService>();
            services.AddTransient<IComuneService, EfCoreComuneService>();
            services.AddTransient<IProvinciaService, AdoNetProvinciaService>();
            services.AddTransient<IRegioneService, AdoNetRegioneService>();
            services.AddTransient<INazioneService, AdoNetNazioneService>();
            services.AddTransient<IDatabaseAccessor, MySqlDatabaseAccessor>();
            services.AddDbContextPool<MyDbContext>(optionsBuilder =>
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=kampus;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.17-mysql"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(routeBuider => {
                routeBuider.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
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
