using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain
{
    public class BookingBase
    {
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(80)]
        public string FullName { get; set; }

    }
}
