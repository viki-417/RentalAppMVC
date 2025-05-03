using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentalAppMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Houses> Houses { get; set; }
        public DbSet<Studio> Studios { get; set; }

    }
}
