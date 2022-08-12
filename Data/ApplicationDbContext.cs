using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moha.Models;

namespace moha.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Mosque>().HasMany(m => m.Participents).WithOne();
           
            base.OnModelCreating(builder);
        }
        public DbSet<Mosque> mosques { get; set; }
        public DbSet<Participent> participents { get; set; }

    }
}