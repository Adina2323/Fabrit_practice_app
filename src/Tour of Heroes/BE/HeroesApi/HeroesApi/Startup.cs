using System.Configuration;
using DataAcessLayer.Models;
using DataAcessLayer.Data;
using DataAcessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HeroesApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Default Policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Change this in production
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Set to true if you want to validate the issuer (usually your API server)
                    ValidateAudience = true, // Set to true if you want to validate the audience (usually the client)
                    ValidateLifetime = true, // Set to true if you want to check the token's expiration date
                    ValidateIssuerSigningKey = true, // Set to true if you want to validate the security key
                    ValidIssuer = "your-issuer", // Replace with your issuer URL or name
                    ValidAudience = "your-audience", // Replace with your audience URL or name
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key")) // Replace with your secret key
                };
            });
        }

        public void OnConfiguring(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
      options.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=HeroesDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"));
        }


    }
}
