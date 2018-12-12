using Brefi.Data.Repositories;
using Brefi.Services.Models;
using System;

namespace Brefi.Services
{
    public class CatalogService
    {
        private EquipmentRepository equipmentRepository;
        private BrendRepository brendRepository;
        private ToolTypeRepository toolTypeRepository;

        public CatalogService(EquipmentRepository eRepository, BrendRepository bRepository, ToolTypeRepository tRepository)
        {
            equipmentRepository = eRepository;
            brendRepository = bRepository;
            toolTypeRepository = tRepository;
        }

        public FullCatalog GetLines(DateTime? date)
        {
            return new FullCatalog
            {
                Brends = brendRepository.GetLines(date),                
                Equipments = equipmentRepository.GetLines(date),
                ToolTypes = toolTypeRepository.GetLines(date)
            };
        }

        public FullCatalog UpdateLines(FullCatalog catalog, DateTime? date)
        {
            if (catalog != null)
            {
                brendRepository.AddOrUpdateRange(catalog.Brends);
                equipmentRepository.AddOrUpdateRange(catalog.Equipments);
                toolTypeRepository.AddOrUpdateRange(catalog.ToolTypes);
            }

            return GetLines(date);
        }

        public string GetDBFile()
        {
            var rn = "\r\n";
            var brends = string.Join(rn, brendRepository.GetStringLines());
            var equipments = string.Join(rn, equipmentRepository.GetStringLines());
            var toolTips = string.Join(rn, toolTypeRepository.GetStringLines());

            return $"Brends{rn}{brends}{rn}Equipmqnt{rn}{equipments}{rn}ToolTips{rn}{toolTips}";
        }
    }
}