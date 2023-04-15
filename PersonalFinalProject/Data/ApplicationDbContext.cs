using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Area >Areas { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
       
        public DbSet<Sitting> Sittings { get; set; }
        public DbSet<ReservationSource> ReservationSources { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<SittingType>   SittingTypes{ get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public ApplicationDbContext()
        {
        }
    }
}