using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Dto.BookingDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("get-list-bookings")]
        public IActionResult GetListBookings()
        {
            var results = _bookingService.GetAll();

            return Ok(results);
        }

        [HttpPost("create-booking")]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
               FullName = createBookingDto.FullName,
               Email = createBookingDto.Email,
               Description = "Rezervasyon Alındı",
               PhoneNumber = createBookingDto.PhoneNumber,
               PersonCount = createBookingDto.PersonCount,
               Date = createBookingDto.Date
            };

            _bookingService.Add(booking);

            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("delete-booking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.GetById(id);

            _bookingService.Remove(value);

            return Ok("Rezervasyon Silindi");
        }

        [HttpPut("update-booking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Id = updateBookingDto.Id,
                FullName = updateBookingDto.FullName,
                Email = updateBookingDto.Email,
                PhoneNumber = updateBookingDto.PhoneNumber,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            };

            _bookingService.Update(booking);

            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("get-by-id-booking/{id}")]
        public IActionResult GetByIdBooking(int id)
        {
            var result = _bookingService.GetById(id);

            return Ok(result);
        }

        [HttpGet("booking-status-approved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);

            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("booking-status-canceled/{id}")]
        public IActionResult BookingStatusCanceled(int id)
        {
            _bookingService.BookingStatusCanceled(id);

            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
    }
}
