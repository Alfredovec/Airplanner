using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Context;
using BLL.Models.Entities;

namespace DAL.Managers
{
    public class AirplannerManager
    {
        private AirplannerContext _context;

        public AirplannerManager()
        {
            _context = new AirplannerContext();   
        }

        public List<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights.OrderBy(fligth => fligth.DepartureTime).ToList();
        }

        public string GetDestinationForFlight(Flight flight)
        {
            Flight f = _context.Flights.Find(flight.FlightId);
            Route r = f.Route;
            City c = r.DestinationCity;
            return _context.Flights.Find(flight.FlightId).Route.DestinationCity.CityName;
        }

        public string GetOutcomeForFlight(Flight flight)
        {
            return _context.Flights.Find(flight.FlightId).Route.OutcomeCity.CityName;
        }
    }
}
