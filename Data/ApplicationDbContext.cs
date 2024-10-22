using Microsoft.EntityFrameworkCore;
using VineriaAPI.Models;

namespace VineriaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }

}
