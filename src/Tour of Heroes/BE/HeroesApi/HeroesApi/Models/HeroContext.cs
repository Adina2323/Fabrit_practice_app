using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Models
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        public DbSet<HeroItem> Heroes { get; set; } = null!;
    }
}
