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
                ToolTypes = toolTypeRepository.GetLines(date),
                Equipments = equipmentRepository.GetLines(date)
            };
        }

        public FullCatalog UpdateLines(FullCatalog catalog, DateTime? date)
        {
            if (catalog != null)
            {
                brendRepository.AddOrUpdateRange(catalog.Brends);
                toolTypeRepository.AddOrUpdateRange(catalog.ToolTypes);
                equipmentRepository.AddOrUpdateRange(catalog.Equipments);
            }

            return GetLines(date);
        }
    }
}