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
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService personsService;

        public PersonsController(IPersonsService personsService)
        {
            this.personsService = personsService;
        }

        // GET: api/Persons
        [HttpGet]
        public IEnumerable<PersonReplyDto> Get()
        {
            return personsService.GetAll().Select(x => new PersonReplyDto().CopyPropertiesFrom(x));       
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        [PersonResultFilter]
        public Person Get(int id)
        {
            return personsService.Get(id);
        }

        // POST: api/Persons
        [HttpPost]
        [PersonResultFilter]
        public Person Post([FromBody] Person value)
        {
            return personsService.Add(value);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        [PersonResultFilter]
        public Person Put(int id, [FromBody] Person value)
        {
            return personsService.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [PersonResultFilter]
        public Person Delete(int id)
        {
            return personsService.Delete(id);
        }
    }
}
