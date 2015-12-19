using System.Data.Entity;
using Models;
using Models.Entities;

namespace DAL
{
    /// <summary>
    /// Operates with database.
    /// </summary>
    public class AirplannerContext : DbContext
    {
        public AirplannerContext()
            : base("AirplannerContext")
        {
            
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Worker> Workers { get; set; }
    }
}
