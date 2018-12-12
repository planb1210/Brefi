using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.WpfApplication.Models
{
    public class ToolType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OptionsDescription { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
