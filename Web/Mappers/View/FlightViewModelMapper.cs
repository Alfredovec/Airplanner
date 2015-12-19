using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Managers;
using Models;
using Models.Entities;
using Models.Enums;
using Web.Models.View;

namespace Web.Mappers.View
{
    /// <summary>
    /// Performing mapping opeartion from FlightViewModel to Flight. 
    /// </summary>
    public class FlightViewModelMapper
    {
        private readonly IAirplannerManager _manager;

        public FlightViewModelMapper(IAirplannerManager manager)
        {
            _manager = manager;
        }

        public Flight Map(FlightViewModel model, bool isNew = false)
        {
            Flight flight = isNew? new Flight() : _manager.GetFlightById(model.Id);
            flight.DepartureTime = model.DepartureTime;
            flight.ArrivalTime = model.ArrivalTime;
            flight.FlightNumber = model.FlightNumber;
            flight.Route = _manager.GetOrCreateRoute(model.OutcomeCityName, model.DestinationCityName);
            return flight;
        }

        public List<Worker> MapWorkers(FlightViewModel model)
        {
            return new List<Worker>
            {
                _manager.GetWorkerByName(model.FirstPilotName, WorkerPosition.FirstPilot),
                _manager.GetWorkerByName(model.SecondPilotName, WorkerPosition.SecondPilot),
                _manager.GetWorkerByName(model.NavigatorName, WorkerPosition.Navigator),
                _manager.GetWorkerByName(model.RadiomanName, WorkerPosition.Radioman),
                _manager.GetWorkerByName(model.FirstSteward, WorkerPosition.Steward),
                _manager.GetWorkerByName(model.SecondSteward, WorkerPosition.Steward),
                _manager.GetWorkerByName(model.ThirdSteward, WorkerPosition.Steward),
            };
        } 
    }
}
