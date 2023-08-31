using System.Configuration;
using DataAcessLayer.Models;
using DataAcessLayer.Data;
using DataAcessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Mappings;

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
        }

        public void OnConfiguring(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
      options.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=HeroesDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"));
        }


    }
}
