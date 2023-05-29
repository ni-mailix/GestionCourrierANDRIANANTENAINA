using Microsoft.EntityFrameworkCore;
using MonNameSpaceGestionCourrier.Models;
using MonNameSpaceGestionCourrier.Data;

namespace MonNameSpaceGestionCourrier.Data
{
    public class GestionCourrierDbContext : DbContext
    {
        public GestionCourrierDbContext(DbContextOptions<GestionCourrierDbContext> options)
            : base(options)
        {
        }

        public DbSet<Courrier> Courriers { get; set; }
        public DbSet<MouvementCourrier> MouvementsCourriers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courrier>()
                .ToTable("Courrier");

            modelBuilder.Entity<MouvementCourrier>()
                .ToTable("MouvementCourrier");
        }
        
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
