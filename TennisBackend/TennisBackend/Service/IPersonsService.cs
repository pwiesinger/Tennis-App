using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackendDb;

namespace TennisBackend.Service
{
    public interface IPersonsService
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        Person Update(int id, Person person);
        Person Delete(int id);
    }
}
