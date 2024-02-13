using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Migrations;

public class ArkDbContext : DbContext
{
    public DbSet<Arks> Arks {get; set;}
    public DbSet<User> Users { get; set; }

    public ArkDbContext(DbContextOptions<ArkDbContext> options)
    : base(options){}

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        base.OnModelCreating(modelbuilder);

        modelbuilder.Entity<Arks>(entity => {
            entity.HasKey(e => e.ArkId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ImgUrl).IsRequired();

        });

        modelbuilder.Entity<User>(entity => {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserName).IsRequired();
            entity.HasIndex(x => x.UserName).IsUnique();
            entity.Property(e => e.Password).IsRequired(); 
        });
    }
}