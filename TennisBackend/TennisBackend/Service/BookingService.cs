using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackendDb;

namespace TennisBackend.Service
{
    public class BookingService : IBookingService
    {
        private readonly TennisBackendDbContext db;

        public BookingService(TennisBackendDbContext db)
        {
            this.db = db;
        }

        public Booking Add(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking;
        }

        public Booking Delete(int id)
        {
            var booking = db.Bookings.First(x => x.Id == id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return booking;
        }

        public Booking Get(int id)
        {
            return db.Bookings.First(x => x.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings.OrderBy(x => x.Id).AsEnumerable();
        }

        public Booking Update(int id, Booking booking)
        {
            var oldBooking = db.Bookings.First(x => x.Id == id);
            oldBooking.CopyPropertiesFrom(booking, new[] { "Id" });
            db.SaveChanges();
            return oldBooking;
        }
    }
}
