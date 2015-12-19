using System.Collections.Generic;
using Models.Enums;

namespace Web.Models.View
{
    /// <summary>
    /// Model representing flights with sorting options.
    /// </summary>
    public class FlightsTableViewModel
    {
        public IEnumerable<FlightViewModel> Flights { get; set; }

        public FlightSortField SortField { get; set; }

        public SortOrder Order { get; set; }
    }
}
