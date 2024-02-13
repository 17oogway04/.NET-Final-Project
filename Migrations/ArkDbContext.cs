using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Migrations;

public class ArkDbContext : DbContext
{
    public DbSet<Arks> Arks {get; set;}
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
    }
}