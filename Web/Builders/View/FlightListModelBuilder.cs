using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.View;
using BLL.Models.Context;
using DAL.Managers;

namespace Web.Builders.View
{
    public class FlightListModelBuilder
    {
        private AirplannerManager _manager;

        public FlightListModelBuilder(AirplannerManager manager)
        {
            _manager = manager;
        }

        public List<FlightViewModel> Build()
        {
            List<FlightViewModel> list = new List<FlightViewModel>();

            foreach (var flight in _manager.GetAllFlights())
            {
                FlightViewModel model = new FlightViewModel();
                model.ArrivalTime = flight.ArrivalTime;
                model.DepartureTime = flight.DepartureTime;
                model.FlightId = flight.FlightId;
                model.DestinationCityName = _manager.GetDestinationForFlight(flight);
                model.OutcomeCityName = _manager.GetOutcomeForFlight(flight);
                list.Add(model);
            }

            return list;
        }
    }
}
