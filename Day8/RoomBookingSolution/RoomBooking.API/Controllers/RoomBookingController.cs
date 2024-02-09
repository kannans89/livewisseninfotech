using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core;
using RoomBooking.Core.Repository;
using System.Globalization;

namespace RoomBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {

        private IBookingRequestProcessor _roomBookingProcessor;

        public RoomBookingController(IBookingRequestProcessor roomBookingProcessor)
        {
            this._roomBookingProcessor = roomBookingProcessor;
        }

        [HttpPost("BookRoom")]
        public async Task<IActionResult> BookRoomAction(BookingRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _roomBookingProcessor.BookRoom(request);
                if (result.Status == BookingStatus.Success)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(nameof(BookingRequest.Date), "No Rooms Available For Given Date");
            }

            return BadRequest(ModelState);
        }

        [HttpGet("AvailableRooms")]
        public async Task<IActionResult> AvailableRooms(string inputDate)
        {
            DateTime mydate;
            if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out mydate) && mydate <= DateTime.Now.Date)
            {
                return BadRequest("Invalid  date format provide yyyy-MM-dd.");
            }

            if (mydate <= DateTime.Now.Date)
            {
                return BadRequest("Only future dates allowed");
            }
            return Ok(_roomBookingProcessor.AvailableRooms(mydate));
        }
    }
}
