using System.Collections.Generic;

namespace Models.Entities
{
    /// <summary>
    /// Implements representation of database entity 'Worker'.
    /// </summary>
    public partial class Worker
    {
        public Worker()
        {
            IsActive = true;
        }

        public int WorkerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } 

    }
}
