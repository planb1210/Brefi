using Brefi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Brefi.Data.Repositories
{
    public class EquipmentRepository
    {
        private BrefiContext db;

        public EquipmentRepository(BrefiContext context)
        {
            db = context;
        }

        public List<Equipment> GetLines(DateTime? date)
        {
            if (date != null)
            {
                return db.Equipments.Where(x => x.UpdateTime > date).ToList();
            }
            return db.Equipments.ToList();
        }

        public List<string> GetStringLines()
        {
            var equipments = db.Equipments.ToList();
            var result = new List<string>();
            foreach (var equipment in equipments)
            {
                var line = $"{equipment.Id},{equipment.Brend},{equipment.ToolTypeId},{equipment.Price},{equipment.UpdateTime},{equipment.IsDeleted}";

                result.Add(line);
            }
            return result;
        }

        public void AddOrUpdate(Equipment equipment)
        {
            var findEquipment = db.Equipments.Where(x => x.Id == equipment.Id).FirstOrDefault();
            if (findEquipment != null)
            {
                findEquipment.Brend = equipment.Brend;
                findEquipment.Description = equipment.Description;
                findEquipment.Price = equipment.Price;
                findEquipment.ToolTypeId = equipment.ToolTypeId;
                findEquipment.UpdateTime = equipment.UpdateTime;
                findEquipment.IsDeleted = equipment.IsDeleted;
            }
            else
            {
                db.Equipments.Add(equipment);
            }
            db.SaveChanges();
        }

        public void AddOrUpdateRange(List<Equipment> equipments)
        {
            if (equipments != null)
            {
                foreach (var equipment in equipments)
                {
                    AddOrUpdate(equipment);
                }
            }
        }

        public void Remove(int id)
        {
            var findEquipment = db.Equipments.Where(x => x.Id == id).FirstOrDefault();
            findEquipment.IsDeleted = true;
            db.SaveChanges();
        }
    }
}
