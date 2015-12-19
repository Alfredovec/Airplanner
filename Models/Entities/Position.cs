using System.Collections.Generic;

namespace Models.Entities
{
    /// <summary>
    /// Implements representation of database entity 'Position'.
    /// </summary>
    public partial class Position
    {
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; } 
    }
}
