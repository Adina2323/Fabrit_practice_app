using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace DataAcessLayer.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<HeroItem> Heroes { get; set; } 

    public DbSet<Image> Images { get; set; } 

    public DbSet<User> Users { get; set; }

    public DbSet<Power> Powers { get; set; }

    public DbSet<HeroItemPower> HeroPowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroItemPower>()
            .HasKey(hp => new { hp.HeroId, hp.PowerId });

        modelBuilder.Entity<HeroItemPower>()
            .HasOne(hp => hp.Hero)
            .WithMany(h => h.Powers)
            .HasForeignKey(hp => hp.HeroId)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<HeroItemPower>()
            .HasOne(hp => hp.Power)
            .WithMany(p => p.HeroPowers)
            .HasForeignKey(hp => hp.PowerId)
            .OnDelete(DeleteBehavior.ClientCascade); 

        modelBuilder.Entity<HeroItemPower>()
            .ToTable("HeroItemPowers");

        modelBuilder.Entity<HeroItemPower>()
           .Property(e => e.Id)
           .ValueGeneratedOnAdd();

        //modelBuilder.Entity<Image>()
        //   .Property(e => e.Id)
        //   .ValueGeneratedOnAdd();
    }

}
