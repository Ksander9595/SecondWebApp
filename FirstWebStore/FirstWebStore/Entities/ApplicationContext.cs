using FirstWebStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebStore.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductBase> ProductBases { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Motocycle> Motocycles { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipments");
            modelBuilder.Entity<Motocycle>().ToTable("Motocycles");
            modelBuilder.Entity<SparePart>().ToTable("Spareparts");
        }
    }
}
