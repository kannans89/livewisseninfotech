using RoomBooking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoomBooking.Core
{
    public class BookingResult : BookingBase
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookingStatus Status { get; set; }
        public int? RoomBookingId { get; set; }
    }
}
