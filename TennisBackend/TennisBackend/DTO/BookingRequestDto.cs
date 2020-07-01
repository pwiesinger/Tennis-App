using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisBackend.DTO
{
    public class BookingRequestDto: BookingDto
    {
        public override string ToString() => $"{Week}";
    }
}
