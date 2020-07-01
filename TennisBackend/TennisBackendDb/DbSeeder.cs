using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisBackendDb
{
    class DbSeeder
    {
        public static void Seed(TennisBackendDbContext db)
        {
            Console.WriteLine("DbSeeder::Seed");

            var person = new Person { Firstname = "Hansi", Lastname = "Huber", Age = 66 };
            var person1 = new Person { Firstname = "Susi", Lastname = "Maier", Age = 23 };
            var person2 = new Person { Firstname = "Fritzi", Lastname = "Hofer", Age = 33 };

            db.Persons.Add(person);
            db.Persons.Add(person1);
            db.Persons.Add(person2);

            db.Bookings.Add(new Booking { DayOfWeek = 2, Week = 22, Hour = 9, Person = person});
            db.Bookings.Add(new Booking { DayOfWeek = 3, Week = 22, Hour = 11, Person = person1 });
            db.Bookings.Add(new Booking { DayOfWeek = 5, Week = 22, Hour = 12, Person = person });
            db.Bookings.Add(new Booking { DayOfWeek = 6, Week = 22, Hour = 13, Person = person1});
            db.Bookings.Add(new Booking { DayOfWeek = 6, Week = 22, Hour = 14, Person = person2 });
            db.Bookings.Add(new Booking { DayOfWeek = 2, Week = 23, Hour = 10, Person = person });


            db.SaveChanges();
        }

        public static void Clear(TennisBackendDbContext db)
        {
            Console.WriteLine("DbSeeder::Clear");
            db.Database.ExecuteSqlRaw("DELETE FROM Persons");
            db.Database.ExecuteSqlRaw("DELETE FROM Bookings");
        }
    }
}
