using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Managers;
using Models.Entities;
using Models.Enums;
using Web.Models.View;

namespace Web.Builders.View
{
    /// <summary>
    /// Performing building opeartion from Flight to FlightViewModel. 
    /// </summary>
    public class FlightViewModelBuilder
    {
        private readonly IAirplannerManager _manager;

        public FlightViewModelBuilder(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public FlightViewModel BuildEmpty()
        {
            FlightViewModel model = new FlightViewModel
            {
                FlightNumber = _manager.GetMaxFlightNumber() + 1,
                DepartureTime = DateTime.Now.AddDays(7),
                ArrivalTime = DateTime.Now.AddDays(14),
                DropDownLists = new Dictionary<string, List<SelectListItem>>
                {
                    { "Cities", _manager.GetCitiesNames()
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "First pilots", _manager.GetWorkersNameByPosition(WorkerPosition.FirstPilot)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Second pilots", _manager.GetWorkersNameByPosition(WorkerPosition.SecondPilot)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Navigators", _manager.GetWorkersNameByPosition(WorkerPosition.Navigator)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Radiomen", _manager.GetWorkersNameByPosition(WorkerPosition.Radioman)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Stewards", _manager.GetWorkersNameByPosition(WorkerPosition.Steward)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() }
                }
            };
            return model;
        }

        public FlightViewModel Build(Flight flight)
        {
            FlightViewModel model = new FlightViewModel
            {
                ArrivalTime = flight.ArrivalTime,
                DepartureTime = flight.DepartureTime,
                FlightNumber = flight.FlightNumber,
                Id = flight.FlightId,
                DestinationCityName = _manager.GetDestinationCityName(flight),
                OutcomeCityName = _manager.GetOutcomeCityName(flight),
                FirstPilotName = _manager.GetWorkerOnFlight(flight, WorkerPosition.FirstPilot),
                SecondPilotName = _manager.GetWorkerOnFlight(flight, WorkerPosition.SecondPilot),
                NavigatorName = _manager.GetWorkerOnFlight(flight, WorkerPosition.Navigator),
                RadiomanName = _manager.GetWorkerOnFlight(flight, WorkerPosition.Radioman),
                FirstSteward = _manager.GetWorkerOnFlight(flight, WorkerPosition.Steward, 1),
                SecondSteward = _manager.GetWorkerOnFlight(flight, WorkerPosition.Steward, 2),
                ThirdSteward = _manager.GetWorkerOnFlight(flight, WorkerPosition.Steward, 3),
                DropDownLists = new Dictionary<string, List<SelectListItem>>
                {
                    { "Cities", _manager.GetCitiesNames()
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "First pilots", _manager.GetWorkersNameByPosition(WorkerPosition.FirstPilot)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Second pilots", _manager.GetWorkersNameByPosition(WorkerPosition.SecondPilot)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Navigators", _manager.GetWorkersNameByPosition(WorkerPosition.Navigator)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Radiomen", _manager.GetWorkersNameByPosition(WorkerPosition.Radioman)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() },

                    { "Stewards", _manager.GetWorkersNameByPosition(WorkerPosition.Steward)
                    .Select((name) => new SelectListItem() { Text = name, Value = name }).ToList() }
                }
            };
            return model;
        }

        public IEnumerable<FlightViewModel> BuildList(FlightStatus status, IEnumerable<Flight> flights = null)
        {
            flights = flights ?? _manager.GetFlights();
            return _manager.GetFlights(flights, status).Select(Build);
        }
    }
}
