using RoomBooking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Repository
{
    public interface IBookingRepsitory
    {
        void Save(Booking booking);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
