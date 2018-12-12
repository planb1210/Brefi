using Brefi.Entities;
using System.Collections.Generic;

namespace Brefi.Services.Models
{
    public class FullCatalog
    {
        public List<Equipment> Equipments { get; set; }

        public List<Brend> Brends { get; set; }

        public List<ToolType> ToolTypes { get; set; }
    }
}
