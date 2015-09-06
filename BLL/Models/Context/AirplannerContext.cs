using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Entities;

namespace BLL.Models.Context
{
    public class AirplannerContext : DbContext
    {
        public AirplannerContext()
            : base("AirplannerContext")
        {
            
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Worker> Workers { get; set; }
    }
}
