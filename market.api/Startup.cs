using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using market.api.Context;
using market.api.Middlewares;
using market.api.Repositories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace market.api
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
            services.AddControllers();

            services.AddDbContext<DatabaseContext>();

            services.AddAuthorization(a => GetAuthorizationOptions());

            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddSingleton<SharedRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MARKET API", Version = "v1" });
            });

            /*
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("User", policy =>
                {
                    policy.RequireRole("ADMIN");
                });
                opt.AddPolicy("Company", policy =>
                {
                    policy.RequireRole("COMPANY");
                });
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
            });
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<AuthorizationLayer>();

            //DatabaseSeeder.Initialize(app);
        }

        public static AuthorizationOptions GetAuthorizationOptions()
        {
            AuthorizationOptions auth = new AuthorizationOptions();
            List<Models.Privilege> privileges = Models.Privilege.GetInitialPrivileges();

            // This policy for authorized users
            auth.AddPolicy("Authorized", pol => pol.RequireAuthenticatedUser());
            privileges.ForEach(privilege => auth.AddPolicy(privilege.Key, policy => policy.RequireClaim(claimType: System.Security.Claims.ClaimTypes.UserData, privilege.Key)));
            return auth;
        }
    }
}
