using Brefi.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brefi.WpfApplication.Data.Repositories
{
    public class ToolTypeRepository
    {
        private Context db;

        public ToolTypeRepository(Context context)
        {
            db = context;
        }

        public List<ToolType> GetLines()
        {
            return db.ToolTypes.Where(x => x.IsDeleted == false).ToList();
        }

        public List<ToolType> GetByTime(DateTime date)
        {
            return db.ToolTypes.Where(x => x.UpdateTime > date).ToList();
        }

        public void AddLines(List<ToolType> toolTypes)
        {
            if (toolTypes.Any())
            {
                foreach (var toolType in toolTypes)
                {
                    AddOrUpdate(toolType);
                }
            }
        }

        public void AddOrUpdate(ToolType toolType)
        {
            var selectedToolType = db.ToolTypes.Where(x => x.Id == toolType.Id).FirstOrDefault();
            if (selectedToolType == null)
            {
                db.ToolTypes.Add(toolType);
            }
            else
            {
                selectedToolType.Name = toolType.Name;
                selectedToolType.OptionsDescription = toolType.OptionsDescription;
                selectedToolType.UpdateTime = toolType.UpdateTime;
                selectedToolType.IsDeleted = toolType.IsDeleted;
            }
            db.SaveChanges();
        }

        public void AddOrUpdateFromDataGrid(ToolType toolType)
        {
            toolType.UpdateTime = DateTime.Now;
            if (toolType.Id == 0)
            {
                db.ToolTypes.Add(toolType);
            }
            db.SaveChanges();
        }
    }
}
