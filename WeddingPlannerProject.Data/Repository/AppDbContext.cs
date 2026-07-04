using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPackage> ProductPackages { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}