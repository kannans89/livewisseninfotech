using RoomBooking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Domain;

namespace RoomBooking.Core
{
    public class BookingRequestProcessor : IBookingRequestProcessor
    {
        private readonly IBookingRepsitory _bookingRepsitory;
        public BookingRequestProcessor(IBookingRepsitory bookingrepostiory)
        {

            _bookingRepsitory = bookingrepostiory;
        }
        public BookingResult BookRoom(BookingRequest request)
        {


            var available = _bookingRepsitory.GetAvailableRooms(request.Date);
            var resultOfBooking = new BookingResult
            {
                FullName = request.FullName,
                Email = request.Email,
                Date = request.Date,

            };

            if (available.Any())
            {
                var room = available.First();

                var booking = new Booking
                {
                    Date = request.Date,
                    Email = request.Email,
                    FullName = request.FullName,
                };

                booking.Room = room;
                _bookingRepsitory.Save(booking);
                resultOfBooking.RoomBookingId = booking.Id;
                resultOfBooking.Status = BookingStatus.Success;

            }
            else
            {
                resultOfBooking.Status = BookingStatus.Failure;
            }

            return resultOfBooking;
        }

        public List<Room> AvailableRooms(DateTime date)
        {
            var availabeRooms = _bookingRepsitory.GetAvailableRooms(date);

            if (availabeRooms.Any())
            {
                return availabeRooms.ToList();
            }
            return new List<Room> { };
        }
    }
}
