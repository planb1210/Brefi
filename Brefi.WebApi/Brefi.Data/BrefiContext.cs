using Brefi.Entities;
using System.Data.Entity;

namespace Brefi.Data
{
    public class BrefiContext : DbContext
    {
        public DbSet<Brend> Brends { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brend>().HasKey(x => x.Id);

            modelBuilder.Entity<Equipment>().HasKey(x => x.Id);
        }
    }
}
