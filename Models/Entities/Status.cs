using System.Collections.Generic;

namespace Models.Entities
{
    /// <summary>
    /// Implements representation of database entity 'Status'.
    /// </summary>
    public partial class Status
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<Flight> Flights { get; set; } 
    }
}
