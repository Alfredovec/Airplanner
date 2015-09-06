using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public virtual ICollection<Route> Routes { get; set; } 
    }
}
