using Brefi.WpfApplication.Models;
using System;
using System.Linq;

namespace Brefi.WpfApplication.Data.Repositories
{
    public class UpdateRepository
    {
        private Context db;

        public UpdateRepository(Context context)
        {
            db = context;
        }

        public bool Any()
        {
            return db.Updates.Any();
        }

        public Update GetLast()
        {
            return db.Updates.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public void AddLine()
        {
            var newUpdate = new Update
            {
                UpdateTime = DateTime.Now
            };

            db.Updates.Add(newUpdate);
            db.SaveChanges();
        }
    }
}
