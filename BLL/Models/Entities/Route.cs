using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Route
    {
        public int RouteId { get; set; }

        public int OutcomeCityId { get; set; }

        public int DestinationCityId { get; set; }

        public virtual City OutcomeCity { get; set; }

        public virtual City DestinationCity { get; set; }

    }
}
