using Brefi.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brefi.WpfApplication.Data.Repositories
{
    public class EquipmentRepository
    {
        private Context db;

        public EquipmentRepository(Context context)
        {
            db = context;
        }

        public List<Equipment> GetLines()
        {
            return db.Equipments.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Equipment> GetByTime(DateTime date)
        {
            return db.Equipments.Where(x => x.UpdateTime > date).ToList();
        }


        public void AddLines(List<Equipment> equipments)
        {
            if (equipments.Any())
            {
                foreach (var equipment in equipments)
                {
                    AddOrUpdate(equipment);
                }
            }
        }

        public void AddOrUpdate(Equipment equipment)
        {
            var selectedEquipment = db.Equipments.Where(x => x.Id == equipment.Id).FirstOrDefault();
            if (selectedEquipment == null)
            {
                db.Equipments.Add(equipment);
            }
            else
            {
                selectedEquipment.BrendId = equipment.BrendId;
                selectedEquipment.ToolTypeId = equipment.ToolTypeId;
                selectedEquipment.Price = equipment.Price;
                selectedEquipment.UpdateTime = equipment.UpdateTime;
                selectedEquipment.IsDeleted = equipment.IsDeleted;
            }
            db.SaveChanges();
        }

        public void AddOrUpdateFromDataGrid(Equipment equipment)
        {
            equipment.UpdateTime = DateTime.Now;
            if (equipment.Id == 0)
            {
                db.Equipments.Add(equipment);
            }
            db.SaveChanges();
        }
    }
}
