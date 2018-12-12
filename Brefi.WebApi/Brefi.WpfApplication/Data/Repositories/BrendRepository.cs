using Brefi.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brefi.WpfApplication.Data.Repositories
{
    public class BrendRepository
    {
        private Context db;

        public BrendRepository(Context context)
        {
            db = context;
        }

        public List<Brend> GetLines()
        {
            return db.Brends.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Brend> GetByTime(DateTime date)
        {
            return db.Brends.Where(x => x.UpdateTime > date).ToList();
        }

        public void AddLines(List<Brend> brends)
        {
            if (brends.Any())
            {
                foreach (var brend in brends)
                {
                    AddOrUpdate(brend);
                }
            }
        }

        public void AddOrUpdate(Brend brend)
        {
            var selectedBrend = db.Brends.Where(x => x.Id == brend.Id).FirstOrDefault();
            if (selectedBrend == null)
            {
                db.Brends.Add(brend);
            }
            else
            {
                selectedBrend.BriefInfo = brend.BriefInfo;
                selectedBrend.Name = brend.Name;
                selectedBrend.UpdateTime = brend.UpdateTime;
                selectedBrend.IsDeleted = brend.IsDeleted;
            }
            db.SaveChanges();
        }

        public void AddOrUpdateFromDataGrid(Brend brend)
        {
            brend.UpdateTime = DateTime.Now;
            if (brend.Id == 0)
            {
                db.Brends.Add(brend);
            }
            db.SaveChanges();
        }
    }
}
