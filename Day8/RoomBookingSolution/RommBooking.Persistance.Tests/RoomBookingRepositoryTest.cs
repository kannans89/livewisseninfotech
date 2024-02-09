using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RoomBooking.Domain;
using RoomBooking.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RommBooking.Persistance.Tests
{
    [TestFixture]
    internal class RoomBookingRepositoryTest
    {
        [Test]
        public void Should_Return_Available_Rooms()
        {
            var date = new DateTime(2024, 02, 10);

            var dbOptions = new DbContextOptionsBuilder<BookingAppDbContext>()
                .UseInMemoryDatabase("mydb")
                .Options;

            using var context = new BookingAppDbContext(dbOptions);
            var room1 = new Room { Id = 1, Name = "Room 1" };
            var room2 = new Room { Id = 2, Name = "Room 2" };
            var room3 = new Room { Id = 3, Name = "Room 3" };

            context.Add(room1);
            context.Add(room2);
            context.Add(room3);

            context.Bookings.Add(new Booking { Room = room1, Date = date, Email = "abc@abc.com", FullName = "abc" });
            context.Bookings.Add(new Booking { Room = room2, Date = date.AddDays(-1), Email = "pqr@pqr.com", FullName = "pqr" });

            context.SaveChanges();

            var repo = new RoomBookingDataRepository(context);

            //Act
            var availableRooms = repo.GetAvailableRooms(date);

            //Assert
            
            Assert.That(availableRooms.Select(q => q.Id).Contains(2));
            Assert.That(availableRooms.Select(q => q.Id).Contains(3));
            Assert.That(!availableRooms.Select(q => q.Id).Contains(1));
            
          
        }

        [Test]
        public void Should_Save_Room_Booking()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingAppDbContext>()
               .UseInMemoryDatabase("mydb")
               .Options;
            var room1 = new Room { Id = 1, Name = "Room 1" };
            var booking = new Booking { Room = room1, Date = new DateTime(2024, 01, 30), Email = "abc@abc.com", FullName = "abc" };


            using var context = new BookingAppDbContext(dbOptions);
            var roomBookingService = new RoomBookingDataRepository(context);
            roomBookingService.Save(booking);

            var bookings = context.Bookings.ToList();


            Assert.That(bookings, Has.Exactly(1).Items);
            //var singleBooking = bookings.Single();

            //Assert.That(singleBooking.Date, Is.EqualTo(booking.Date));
            //Assert.That(singleBooking.Room.Id, Is.EqualTo(booking.Room.Id));
        }
    }
}
