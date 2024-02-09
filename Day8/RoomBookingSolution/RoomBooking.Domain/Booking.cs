using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain
{
    public class Booking:BookingBase
    {
        public int Id { get; set; }
        public Room Room { get; set; }


    }
}
