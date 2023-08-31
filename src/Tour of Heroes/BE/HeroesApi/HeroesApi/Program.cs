using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Data;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Repositories.Users;
using HeroesApi;
using DataAcessLayer.Mappings;
using BusinessLogicLayer;
using BusinessLogicLayer.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString),ServiceLifetime.Transient);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
