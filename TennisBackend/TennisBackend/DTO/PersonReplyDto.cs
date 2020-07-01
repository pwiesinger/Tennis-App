using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisBackend.DTO
{
    public class PersonReplyDto : PersonDto
    {
        public int Id { get; set; }
        public override string ToString() => $"{Lastname} [{Id}]";
    }
}
