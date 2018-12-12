using Brefi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brefi.Data.Repositories
{
    public class BrendRepository
    {
        private BrefiContext db;

        public BrendRepository(BrefiContext context)
        {
            db = context;
        }

        public List<Brend> GetLines(DateTime? date)
        {
            if (date != null)
            {
                return db.Brends.Where(x => x.UpdateTime > date).ToList();
            }
            return db.Brends.ToList();
        }

        public void AddOrUpdate(Brend brend)
        {
            var findBrend = db.Brends.Where(x => x.Id == brend.Id).FirstOrDefault();
            if (findBrend != null)
            {
                findBrend.Name = brend.Name;
                findBrend.BriefInfo = brend.BriefInfo;
                findBrend.UpdateTime = brend.UpdateTime;
                findBrend.IsDeleted = brend.IsDeleted;
            }
            else
            {
                db.Brends.Add(brend);
            }
            db.SaveChanges();
        }

        public void AddOrUpdateRange(List<Brend> brends)
        {
            if (brends != null)
            {
                foreach (var brend in brends)
                {
                    AddOrUpdate(brend);
                }
            }
        }

        public void Remove(int id)
        {
            var findBrend = db.Brends.Where(x => x.Id == id).FirstOrDefault();
            findBrend.IsDeleted = true;
            db.SaveChanges();
        }
    }
}
