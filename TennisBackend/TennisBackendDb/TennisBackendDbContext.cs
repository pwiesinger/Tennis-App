using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisBackendDb
{
    public class TennisBackendDbContext : DbContext
    {
        public TennisBackendDbContext(DbContextOptions<TennisBackendDbContext> options) : base(options) { }
        public TennisBackendDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "data source=(LocalDB)\\mssqllocaldb; attachdbfilename=D:\\Temp\\Tennis.mdf;database=TennisDb;integrated security=True; MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
