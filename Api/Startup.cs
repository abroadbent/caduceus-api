using System;
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
using Api.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.Text;

namespace Api
{
    public class Startup
    {
        private readonly IConfigurationSection _jwtOptions;
        private readonly SymmetricSecurityKey _signedKey;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _jwtOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            _signedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions[nameof(JwtIssuerOptions.SigningKey)]));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add framework services
            services.AddCors(options => {
                               options.AddPolicy("CorsPolicy", (builder) => builder
                               .WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowCredentials()
                               .AllowAnyHeader());
            });
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("DefaultConnection"))));
            services.AddAutoMapper();

            // add app services
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IJwtService, JwtService>();

            // jwt token authorization configuration
            var jwtOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signedKey, SecurityAlgorithms.HmacSha256);
            });
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

			// jwt token authorization configuration
			var jwtOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)],
				ValidateAudience = true,
				ValidAudience = jwtOptions[nameof(JwtIssuerOptions.Audience)],
				ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signedKey,
				RequireExpirationTime = false,
				ValidateLifetime = false,
				ClockSkew = TimeSpan.Zero
			};
        }
    }
}
