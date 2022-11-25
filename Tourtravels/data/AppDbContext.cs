
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tourtravels.Models;
using TourTravels.Models;

namespace Tourtravels.data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tour_place>().HasKey(tp => new
            {
                tp.PlaceId,
                tp.TourId
            });
            modelBuilder.Entity<Tour_place>().HasOne(t => t.tour).WithMany(tp => tp.Tours_Places).HasForeignKey(t => t.TourId);

            modelBuilder.Entity<Tour_place>().HasOne(t => t.place).WithMany(tp => tp.Tours_Places).HasForeignKey(t => t.PlaceId);



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Places> Place { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Tour_place> Tour_Places { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Guide> Guides { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get ; set; }
        public DbSet<OrderItem1> OrderItems  { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


       

    }
}
