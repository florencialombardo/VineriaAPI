using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            // Configurar reglas, como restricciones o relaciones
            modelBuilder.Entity<Wine>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }

}
