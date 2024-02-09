using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain;

namespace RoomBooking.Persistance
{
    public class BookingAppDbContext : DbContext
    {
        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }//table
        public DbSet<Booking> Bookings { get; set; }//table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Conference Room A", Capacity = 2 },
                new Room { Id = 2, Name = "Conference Room B", Capacity = 3 },
                new Room { Id = 3, Name = "Conference Room C", Capacity = 4 }
            );
        }
    }
}
