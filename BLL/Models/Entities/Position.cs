using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Position
    {
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; } 
    }
}
