using Microsoft.EntityFrameworkCore;

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
                .Property(c => c.Urgent_O_N)
                .HasConversion<string>();
        }
    }
}
