using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Models;

namespace DataAcessLayer.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<HeroItem> Heroes { get; set; } 

    public DbSet<Image> Images { get; set; } 

    public DbSet<User> Users { get; set; }

}
