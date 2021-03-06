﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Api.Services.AppUserService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.Text;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Services.TenantService;
using System.IdentityModel.Tokens.Jwt;

namespace Api
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
            // add configuration information
            var authConfig = Configuration.GetSection("Auth").Get<AuthConfiguration>();
            services.AddSingleton(authConfig);

            // add framework services
            services.AddCors(options => {
                               options.AddPolicy("CorsPolicy", (builder) => builder
                               .WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowCredentials()
                               .AllowAnyHeader());
            });
            services.AddLogging(options =>
            {
                options.AddConsole();
                options.AddDebug();
            });
            services.AddMvc();
            services.AddDbContext<AppUserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("DefaultConnection"))));
            services.AddAutoMapper();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Audience = authConfig.JwtAudience;
                    options.Authority = authConfig.JwtAuthority;
                    options.RequireHttpsMetadata = false;
                    options.Validate();
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim(JwtRegisteredClaimNames.Sub));
                options.AddPolicy("Admin", policy => policy.RequireClaim("IsAdmin", "true"));
                options.AddPolicy("SysAdmin", policy => policy.RequireClaim("IsSysAdmin", "true"));
            });

            // add app services
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IInventoryItemService, InventoryItemService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ITenantService, TenantService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
