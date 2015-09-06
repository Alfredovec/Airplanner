using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Flight
    {
        public Flight()
        {
            IsActive = true;
        }

        public int FlightId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public bool IsActive { get; set; }

        public int RouteId { get; set; }

        public int StatusId { get; set; }

        public virtual Route Route { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Worker> Workers { get; set; } 


    }
}
