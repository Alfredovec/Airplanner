namespace Web.Models.View
{
    /// <summary>
    /// Model representing search and table of flights.
    /// </summary>
    public class FlightListViewModel
    {   
        public FlightSearchViewModel SearchViewModel { get; set; }

        public FlightsTableViewModel FlightsTableViewModel { get; set; }
    }
}
