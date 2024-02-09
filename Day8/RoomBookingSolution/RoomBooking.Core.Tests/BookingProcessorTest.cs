using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RoomBooking.Core.Repository;
using RoomBooking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Tests
{
    [TestFixture]
    public class BookingProcessorTest
    {
        [Test]
        public void BookRoom_WhenCalled_ShouldNotReturnNullResultIfRoomsAvaialbe()
        {

            var request = new BookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2024, 10, 20)
            };
            var availableRooms = new List<Room>() { new Room() { Id = 1 } };
            var service = new Mock<IBookingRepsitory>();

            service.Setup(s => s.GetAvailableRooms(request.Date))
                .Returns(availableRooms);

            var processor = new BookingRequestProcessor(service.Object);
            BookingResult result = processor.BookRoom(request);

            Assert.That(result, Is.Not.Null);
           
        }

        [Test]
        public void Should_Return_RoomBookingId_In_Result()
        {

            var bookingId = 1002;
            var request = new BookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2024, 10, 20)
            };
            var availableRooms = new List<Room>() { new Room() { Id = 1 } };
            var repo = new Mock<IBookingRepsitory>();

            repo.Setup(s => s.GetAvailableRooms(request.Date))
                .Returns(availableRooms);

            repo.Setup(q => q.Save(It.IsAny<Booking>()))
               .Callback<Booking>(booking =>
               {
                   booking.Id = bookingId;
               });

            var processor = new BookingRequestProcessor(repo.Object);
            var result = processor.BookRoom(request);

            Assert.That(result.RoomBookingId, Is.EqualTo(bookingId));



        }

    }
}
