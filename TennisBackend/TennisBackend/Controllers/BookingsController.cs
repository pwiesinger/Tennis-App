using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisBackend.DTO;
using TennisBackend.Filter;
using TennisBackend.Service;
using TennisBackendDb;

namespace TennisBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET: api/Bookings
        [HttpGet]
        public IEnumerable<BookingReplyDto> Get()
        {
            return bookingService.GetAll().Select(x => new BookingReplyDto() { PersonId = x.PersonId}.CopyPropertiesFrom(x));
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        [BookingResultFilter]
        public Booking Get(int id)
        {
            return bookingService.Get(id);
        }

        // POST: api/Bookings
        [HttpPost]
        [BookingResultFilter]
        public Booking Post([FromBody] Booking value)
        {
            return bookingService.Add(value);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        [BookingResultFilter]
        public Booking Put(int id, [FromBody] Booking value)
        {
            return bookingService.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [BookingResultFilter]
        public Booking Delete(int id)
        {
            return bookingService.Delete(id);
        }
    }
}
