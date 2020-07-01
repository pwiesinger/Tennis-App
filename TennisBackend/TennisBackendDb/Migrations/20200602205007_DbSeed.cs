using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;

namespace TennisBackendDb.Migrations
{
    public partial class DbSeed : Migration
    {
        public static TennisBackendDbContext CreateContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TennisBackendDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Tennis"));
            return new TennisBackendDbContext(optionsBuilder.Options);
        }


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var db = CreateContext();
            DbSeeder.Seed(db);
            db.Dispose();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var db = CreateContext();
            DbSeeder.Clear(db);
            db.Dispose();
        }
    }
}
