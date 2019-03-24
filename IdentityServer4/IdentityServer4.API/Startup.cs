using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.API.Infrastructure;
using IdentityServer4.API.Security;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static IdentityServer4.Models.IdentityResource;
using IdentityServer4.Validation;
using IdentityServer4.Services;
using System.Reflection;
using IdentityServer4.API.Enityframework.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.API
{
    public class Startup
    {
        private const string IDENTITY_SERVER_IP = "https://localhost:44397"; //For test environment

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString)
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //    services.AddIdentityServer()
            //            .AddInMemoryIdentityResources(Config.GetIdentityScopes())
            //.AddInMemoryApiResources(Config.GetApiScopes())
            //.AddInMemoryClients(Config.GetClients())
            //.AddTestUsers(Config.GetUsers())
            //.AddTemporarySigningCredential();

            services.AddTransient<IAuthRepository, AuthRepository>();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();



            services.AddIdentityServer()
                   .AddDeveloperSigningCredential()
       .AddInMemoryApiResources(Config.GetApiScopes())
       .AddInMemoryClients(Config.GetClients());

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(option =>
                 {
                   
                     option.Authority = IDENTITY_SERVER_IP;
                     option.RequireHttpsMetadata = true;
                          option.ApiSecret = "secretkey";
                          option.ApiName = "api"; //This is the resourceAPI that we defined in the Config.cs in the LoginWeb project above. In order to work it has to be named equal.
                      });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseIdentityServer();
            app.UseHttpsRedirection();
            app.UseMvc();

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            //Configuration = builder.Build();
        }
    }
}
