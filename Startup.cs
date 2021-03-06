﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using KampusStudioProto.Customizations.Identity;
using KampusStudioProto.Models.Entities;
using KampusStudioProto.Models.Options;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
            services.AddRazorPages(options =>{
                options.Conventions.AllowAnonymousToPage("/Privacy");
            });
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });
            services.AddMvc(options => {
                AuthorizationPolicyBuilder policyBuilder = new();
                AuthorizationPolicy policy = policyBuilder.RequireAuthenticatedUser().Build();
                AuthorizeFilter filter = new(policy);
                options.Filters.Add(filter);
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
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
                options.SignIn.RequireConfirmedAccount = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<MyDbContext>();

            /****** INIZIO CONFIGURAZIONE SERVIZI APPLICATIVI ******/
            services.AddTransient<IHomeService, AdoNetHomeService>();
            services.AddTransient<IAziendaService, AdoNetAziendaService>();

            services.AddTransient<IComuneService, AdoNetComuneService>();
            //services.AddTransient<IComuneService, EfCoreComuneService>();

            services.AddTransient<IProvinciaService, AdoNetProvinciaService>();
            services.AddTransient<IRegioneService, AdoNetRegioneService>();

            services.AddTransient<INazioneService, AdoNetNazioneService>();
            //services.AddTransient<INazioneService, EfCoreNazioneService>();

            services.AddTransient<IEnteService, AdoNetEnteService>();
            //services.AddTransient<IEnteService, EfCoreEnteService>();

            services.AddTransient<IDatabaseAccessor, MySqlDatabaseAccessor>();
            /****** FINE CONFIGURAZIONE SERVIZI APPLICATIVI ******/

            services.AddSingleton<IEmailSender, MailKitEmailSender>();
            services.AddDbContextPool<MyDbContext>(optionsBuilder =>
            {
                string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.17-mysql"));
            });

            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
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
