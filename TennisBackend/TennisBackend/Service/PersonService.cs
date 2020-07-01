using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBackendDb;

namespace TennisBackend.Service
{
    public class PersonService : IPersonsService
    {
        private readonly TennisBackendDbContext db;

        public PersonService(TennisBackendDbContext db)
        {
            this.db = db;
        }

        public Person Add(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return person;
        }

        public Person Delete(int id)
        {
            var person = db.Persons.First(x => x.Id == id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return person;
        }

        public Person Get(int id)
        {
            return db.Persons.First(x => x.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Persons.OrderBy(x => x.Lastname).AsEnumerable();
        }

        public Person Update(int id, Person person)
        {
            var oldPerson = db.Persons.First(x => x.Id == id);
            oldPerson.CopyPropertiesFrom(person, new[] { "Id" });
            db.SaveChanges();
            return oldPerson;
        }
    }
}
