using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisBackend.DTO
{
    public class PersonRequestDto : PersonDto
    {
        public override string ToString() => $"{Lastname}";
    }
}
