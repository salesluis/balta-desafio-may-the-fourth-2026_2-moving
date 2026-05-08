using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pgvector;

namespace balta_desafio_may_the_fourth_2026_2_moving.Infra.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Box> Boxes { get; set; }
    public DbSet<ItemBox> ItemBoxes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemBox>(entity =>
        {
            modelBuilder.HasPostgresExtension("vector");

            modelBuilder.Entity<ItemBox>(typeBuilder =>
            {
                typeBuilder.ToTable("items");

                typeBuilder.Property(e => e.Embedding)
                    .HasColumnType("vector(768)")
                    .HasConversion(
                        v => new Vector(v),        // float[] → Vector (escrita)
                        v => v.ToArray()           // Vector → float[] (leitura)
                    );
            });
        });
    }
}