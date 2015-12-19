using System.Collections.Generic;

namespace Models.Entities
{
    /// <summary>
    /// Implements representation of database entity 'City'.
    /// </summary>
    public partial class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public virtual ICollection<Route> Routes { get; set; } 
    }
}
