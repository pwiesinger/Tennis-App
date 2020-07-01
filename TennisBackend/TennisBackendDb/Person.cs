using System;
using System.Collections.Generic;
using System.Text;

namespace TennisBackendDb
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
