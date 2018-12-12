using Brefi.WpfApplication.Models;
using System.Data.Entity;

namespace Brefi.WpfApplication.Data
{
    public class Context: DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Brend> Brends { get; set; }
        public DbSet<ToolType> ToolTypes { get; set; }
        public DbSet<Update> Updates { get; set; }

        public Context() : base("DefaultConnection")
        {
        }
    }
}
