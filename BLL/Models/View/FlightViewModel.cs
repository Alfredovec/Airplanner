using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.View
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string OutcomeCityName { get; set; }

        public string DestinationCityName { get; set; }
    }
}
