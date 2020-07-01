using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackendDb;

namespace TennisBackend.Service
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Booking Get(int id);
        Booking Add(Booking booking);
        Booking Update(int id, Booking booking);
        Booking Delete(int id);
    }
}
