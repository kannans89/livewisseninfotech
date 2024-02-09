using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RoomBooking.API.Controllers;
using RoomBooking.Core;

namespace RoomBooking.API.Tests
{
    [TestFixture]
    public class RoomBookingControllerTest
    {
        [Test]
        public async Task Should_Call_BookRoomProcessor_Method_When_ModelStateValid()
        {



            var processor = new Mock<IBookingRequestProcessor>();
            var controller = new RoomBookingController(processor.Object);
            var req = new BookingRequest();
            var result = new BookingResult();

            processor.Setup(x => x.BookRoom(req)).Returns(result);

            result.Status = BookingStatus.Success;

            var actionResult = await controller.BookRoomAction(req);

            Assert.That(actionResult, Is.InstanceOf<OkObjectResult>());

            processor.Verify(x => x.BookRoom(req), Times.Exactly(1));
        }

        [Test]
        public async Task Should_NotCall_BookRoomProcessor_Method_When_ModelStateNotValid()
        {



            var processor = new Mock<IBookingRequestProcessor>();
            var controller = new RoomBookingController(processor.Object);
            var req = new BookingRequest();
            var result = new BookingResult();
            processor.Setup(x => x.BookRoom(req)).Returns(result);
            result.Status = BookingStatus.Success;
            //adding error
            controller.ModelState.AddModelError("Key", "ErrorMessage");

            //act
            var actionResult = await controller.BookRoomAction(req);

            //assert
            Assert.That(actionResult, Is.InstanceOf<BadRequestObjectResult>());
            processor.Verify(x => x.BookRoom(req), Times.Exactly(0));
        }

    }
}
