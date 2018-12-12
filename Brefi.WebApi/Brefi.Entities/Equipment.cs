using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.Entities
{
    public class Equipment
    {
        public int Id { get; set; }

        public Brend Brend { get; set; }

        public int ToolTypeId { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
