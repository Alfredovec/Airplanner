using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Entities
{
    public partial class Request
    {
        public int RequestId { get; set; }

        public int FligthId { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
