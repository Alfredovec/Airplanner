using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Web.Models.View
{
    public class ReportViewModel
    {
        public string PilotFirstName { get; set; }
        public string PilotLastName { get; set; }
        public int MinutesFlown { get; set; }
        public IEnumerable<Route> Routes { get; set; }
    }
}
