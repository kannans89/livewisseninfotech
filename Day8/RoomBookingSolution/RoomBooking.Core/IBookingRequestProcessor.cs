using RoomBooking.Domain;

namespace RoomBooking.Core
{
    public interface IBookingRequestProcessor
    {
        BookingResult BookRoom(BookingRequest request);
        List<Room> AvailableRooms(DateTime date);
    }
}