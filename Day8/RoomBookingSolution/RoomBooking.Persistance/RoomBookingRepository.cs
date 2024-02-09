using RoomBooking.Core.Repository;
using RoomBooking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Persistance
{
    public class RoomBookingDataRepository : IBookingRepsitory
    {
        private readonly BookingAppDbContext _context;

        public RoomBookingDataRepository(BookingAppDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            return _context.Rooms.Where(q => q.Bookings.All(x => x.Date != date))
                .ToList();
        }

        public void Save(Booking roomBooking)
        {
            _context.Bookings.Add(roomBooking);
            _context.SaveChanges();
        }
    }
}
