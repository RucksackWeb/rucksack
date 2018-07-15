using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Data;
using ECommerceStore.Models;
using ECommerceStore.Models.Handler;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WarehouseDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("WarehouseLocalDB")));
            //options.UseSqlServer(Configuration.GetConnectionString("WarehouseDeployedDB")));

            services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserLocalDB")));
            //options.UseSqlServer(Configuration.GetConnectionString("UserDeployedDB")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();


            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
                option.AddPolicy("SubscribersOnly", policy => policy.RequireClaim("Subscription"));
            });


            services.AddSingleton<IAuthorizationHandler, AdminOnlyHandler>();
            services.AddTransient<IAuthorizationHandler, SubscriberFeatureHandler>();
            services.AddScoped<IInventory, DevInventory>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("un-break me");
            });
        }
    }
}
