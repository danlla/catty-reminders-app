using ExampleWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebService;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Word> Words { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Word>(entity =>
        {
            entity.ToTable("words");
            entity.HasKey(e => e.Id);

            entity.Property(w => w.Id)
              .ValueGeneratedOnAdd();

            entity.Property(e => e.Text)
                  .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
