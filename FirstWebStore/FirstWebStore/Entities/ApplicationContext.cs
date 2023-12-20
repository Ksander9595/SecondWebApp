using FirstWebStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebStore.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Motocycle> Motocycles { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Product>(b =>
        //    {
        //        b.HasOne(_ => _.Equipment).WithOne(_ => _.Product).HasForeignKey("ProductId");
        //    });
        //}
    }
}
