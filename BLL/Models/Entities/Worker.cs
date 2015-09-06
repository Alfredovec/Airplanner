using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Worker
    {
        public Worker()
        {
            IsActive = true;
        }

        public int WorkerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } 

    }
}
