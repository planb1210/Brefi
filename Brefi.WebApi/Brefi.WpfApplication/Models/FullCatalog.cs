using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.WpfApplication.Models
{
    public class FullCatalog
    {
        public List<Equipment> Equipments { get; set; }

        public List<Brend> Brends { get; set; }

        public List<ToolType> ToolTypes { get; set; }
    }
}