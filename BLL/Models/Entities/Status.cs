using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Status
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<Flight> Flights { get; set; } 
    }
}
