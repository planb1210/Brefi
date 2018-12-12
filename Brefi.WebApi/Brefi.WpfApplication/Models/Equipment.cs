using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.WpfApplication.Models
{
    public class Equipment : BaseModel
    {
        public int BrendId{ get; set; }

        public int ToolTypeId { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
