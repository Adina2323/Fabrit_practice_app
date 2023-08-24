using System.Configuration;
using HeroesApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

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
        }

        public void OnConfiguring(IServiceCollection services)
        {
            services.AddDbContext<HeroContext>(options =>
      options.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=HeroesDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"));
        }


    }
}
