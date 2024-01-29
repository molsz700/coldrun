using Coldrun.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coldrun.Database;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Truck> Trucks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.Property(e => e.Code).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
